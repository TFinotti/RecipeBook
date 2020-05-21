using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes => context.Recipes;

        public void AddRecipe(Recipe recipe)
        {
            if (recipe.RecipeId == 0)
            {
                context.Recipes.Add(recipe);
            }

            else
            {
                Recipe recipeEntry = context.Recipes
                    .FirstOrDefault(r => r.RecipeId == recipe.RecipeId);

                if(recipeEntry != null)
                {
                    recipeEntry.Title = recipe.Title;
                    recipeEntry.Author = recipe.Author;
                    recipeEntry.PrepTime = recipe.PrepTime;
                    recipeEntry.CookTime = recipe.CookTime;
                    recipeEntry.Ingredients = recipe.Ingredients;
                    recipeEntry.Steps = recipe.Steps;
                }
            }

            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int id)
        {
            Recipe recipeEntry = context.Recipes
                    .FirstOrDefault(r => r.RecipeId == id);

            if(recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }

            return recipeEntry;
        }
    }
}
