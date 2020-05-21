using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Models;

namespace RecipeBook.Controllers
{
    public class AdminController : Controller
    {
        private IRecipeRepository repository;

        public AdminController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Update(int id)
        {
            return View(repository.Recipes.
                FirstOrDefault(r => r.RecipeId == id));
        }

        [HttpPost]
        public IActionResult Update(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.AddRecipe(recipe);
                TempData["message"] = $"{recipe.Title} has been updated!";
                return RedirectToAction("../Home/RecipeList");
            }
            else
            {
                return View(recipe);
            }
        }

        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.AddRecipe(recipe);
                return View("RecipeAdded");
            }

            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(id);

            if(deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Title} was deleted!";
            }

            return RedirectToAction("../Home/RecipeList");
        }
    }
}