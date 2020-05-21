using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }

        //public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
