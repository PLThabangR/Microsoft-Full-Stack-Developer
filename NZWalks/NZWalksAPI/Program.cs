using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NZWalksAPI.Data;
using NZWalksAPI.Mappings;
using NZWalksAPI.Reositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Look atb the routes and documents them
builder.Services.AddEndpointsApiExplorer();
///COnvet so the documentation meet open ape standards
///generate Swagger documentation in an OpenAPI format.
builder.Services.AddSwaggerGen();

///Inject deContext so it can be used anywh where and provide dbContext 
/// the appplication will manage the instances of the dbContext
builder.Services.AddDbContext<NZWalkDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnection")));
//inject auth db context
builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalkAuthConnection")));
//Inject identity Solutions

// Configure Identity
builder.Services.AddIdentityCore<IdentityUser>() // Add Identity
    .AddRoles<IdentityRole>() // Add role support
    .AddEntityFrameworkStores<AuthDbContext>() // Use the AuthDbContext for storage
    .AddDefaultTokenProviders() // Add token providers for password  reset, email confirmation
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NZWalks"); // Add token providers


//Identity options for password policy
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

//Inject the region repository into the controller
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
// Inject the walk repository into the controller
builder.Services.AddScoped<IWalkRepository, WalkServiceRepository>();

 
//Inject auto mapper 
builder.Services.AddAutoMapper(cfg => cfg.AddProfile(typeof(AutoMapperProfile)));


//Add Authentication to the sevices
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
{   //validate the token
   ValidateIssuer = true,
   //validate the audience
   ValidateAudience = true,
   ValidateLifetime = true,
   ValidateIssuerSigningKey = true, //validate the signing key'
   ValidIssuer = builder.Configuration["Jwt:Issuer"],
   ValidAudience = builder.Configuration["Jwt:Audience"],
   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   // to produce the Swagger JSON document.
    app.UseSwagger();
    //to create a visual interface for browsing and testing endpoints.
    app.UseSwaggerUI();
}

//Middleware
app.UseHttpsRedirection();
//
app.UseAuthentication();
//
app.UseAuthorization();

//
app.MapControllers();

app.Run();
