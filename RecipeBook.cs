﻿using System.Collections.Generic;

namespace RecipeApp
{
    public class RecipeBook
    {
        private List<Recipe> recipes;

        public RecipeBook()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipe.OnCaloriesExceeded += DisplayCalorieWarning;
            recipes.Add(recipe);
        }

        public List<Recipe> GetAllRecipes()
        {
            return recipes;
        }

        private void DisplayCalorieWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            ResetConsoleColor();
        }

        private void ResetConsoleColor()
        {
            Console.ResetColor();
        }
    }
}
