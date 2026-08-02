using System;
using Sytem.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")] //limit to 18 digits, 2 decimals
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")] //limit to 18 digits, 2 decimals
        public decimal Purchase{ get; set; }

        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;

        public string MarketCap { get; set; } = string.Empty;

        //One to many relationship
        public List<Comment> StockPrices { get; set; } = new List<Comment>();
     
        
    }
}