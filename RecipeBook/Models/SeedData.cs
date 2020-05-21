using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace RecipeBook.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        Title = "Crockpot Chicken Fajitas",
                        Author = "Makinze Gore",
                        PrepTime = 5,
                        CookTime = 360,
                        Ingredients = "4 boneless, skinless chicken breasts\n3 bell peppers, thinly sliced\n1 onion, thinly sliced\n1 (14-oz.) can diced tomatoes\n2 tsp.cumin\n1/2 tsp. red pepper flakes\nKosher salt\nFreshly ground black pepper",
                        Steps = "Place chicken, bell peppers, and onions in slow-cooker then pour over diced tomatoes. Season with cumin, red pepper flakes, salt, and pepper. Cook on low for 6 hours, or until chicken is cooked through.\nRemove chicken from slow-cooker and slice into strips. Serve fajitas in tortillas with desired toppings."
                        /*Reviews =
                        {
                            new Review{
                                Comments = "Very easy and tasty!",
                                Author = "Clair Linn"
                            },
                            new Review
                            {
                                Comments = "Perfect for family dinner",
                                Author = "Anderson Marvin"
                            }
                        }*/
                    },

                new Recipe
                {
                    Title = "Slow-Cooker Louisiana Ribs",
                    Author = "Lauren Miyashiro",
                    PrepTime = 15,
                    CookTime = 480,
                    Ingredients = "1/4 c. brown sugar\n1 tbsp. Cajun seasoning\n2 tsp. kosher salt\n1 tsp. dried oregano\n1/2 tsp. onion powder\n2 lb. baby back ribs, trimmed and cut into 4 to 5 pieces\n1 c. barbecue sauce, divided\n1/2 c. water",
                    Steps = "In a small bowl, whisk together brown sugar, cajun seasoning, salt, oregano, and onion powder. Pat ribs dry with a paper towel then rub spice mixture onto ribs.\nBrush about ½ cup barbecue sauce onto ribs and place in slow cooker. Pour water around the ribs and cook on low until tender, about 8 hours.\nBrush the remaining barbecue sauce on the ribs."
                    /*Reviews =
                    {
                        new Review{
                            Comments = "Great!",
                            Author = "Jake Doe"
                        },
                        new Review
                        {
                            Comments = "Delicious!",
                            Author = "John Cena"
                        }
                    }*/
                }
                    );

                context.SaveChanges();
            }
        }
    }
}
