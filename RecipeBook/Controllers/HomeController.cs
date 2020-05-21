using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Models;

namespace RecipeBook.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeRepository repository;

        public HomeController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult RecipeList()
        {
            return View(repository.Recipes);
        }

        public ViewResult ViewRecipe(int id)
        {
            return View(repository.Recipes
                           .FirstOrDefault(r => r.RecipeId == id)
                            );
        }

    }
}
