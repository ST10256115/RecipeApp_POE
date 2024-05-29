using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public event Program.CalorieNotification OnCaloriesExceeded;

        public Recipe(string name, List<Ingredient> ingredients, List<string> steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;

            if (GetTotalCalories() > 300)
            {
                OnCaloriesExceeded?.Invoke($"Warning: The recipe \"{name}\" exceeds 300 calories!");
            }
        }

        public double GetTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories * ingredient.Quantity);
        }

        public override string ToString()
        {
            string recipe = "Ingredients:\n";
            foreach (var ingredient in Ingredients)
            {
                recipe += $"{ingredient}\n";
            }

            recipe += "\nSteps:\n";
            for (int i = 0; i < Steps.Count; i++)
            {
                recipe += $"{i + 1}. {Steps[i]}\n";
            }

            recipe += $"\nTotal Calories: {GetTotalCalories()}\n";

            return recipe;
        }
    }
}
