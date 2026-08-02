using System;
using Sytem.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Comment
    {
        //primary key
        public int Id { get; set; }

        // Title and content
        public string Title { get; set; } = string.Empty;

        // Content
        public string Content { get; set; } = string.Empty; 

    public DateTime CreatedDate { get; set; }  = DateTime.Now;
        //One to many relattionship
        public int? StockID { get; set; } //key to form relationship
        public Stock? Stock { get; set; } //navigation property allow us to access stock model 
    }
}