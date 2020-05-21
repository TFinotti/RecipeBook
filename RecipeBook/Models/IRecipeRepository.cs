using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }

        void AddRecipe(Recipe recipe);

        Recipe DeleteRecipe(int id);
    }
}
