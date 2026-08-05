
using AutoMapper;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.Dtos;

namespace NZWalksAPI.Mappings
{
    public class AutoMapperProfile:Profile
    {
        //Implementing AutoMapper Profile
        public AutoMapperProfile()
        {   //CreateMap<TSource,TDestination>
            CreateMap<Region,RegionDto>().ReverseMap();
            CreateMap<Region,AddRegionDto>().ReverseMap();
            CreateMap<Region,UpdateRegionDto>().ReverseMap();

            //Mapping for Walks
            //CreateMap<Walk,WalkDto>().ReverseMap();
            CreateMap<Walk,CreateWalkDto>().ReverseMap();
            CreateMap<Walk,WalkDto>().ReverseMap();
            CreateMap<Walk,UpdateWalkDto>().ReverseMap();
           
            //Mapping for Difficulty
            CreateMap<Difficulty,DifficultyDto>().ReverseMap();
            // CreateMap<Difficulty,CreateDifficultyDto>().ReverseMap();
            // CreateMap<Difficulty,UpdateDifficultyDto>().ReverseMap();

        }
    }
}
