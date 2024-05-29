using System;
using System.Collections.Generic;

namespace RecipeApp
{
    class Recipe//functions and procedures
    {
        private readonly List<Ingredient> originalIngredients; // Store original ingredients
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe(List<Ingredient> ingredients, List<string> steps)
        {
            Ingredients = ingredients;
            Steps = steps;
            originalIngredients = new List<Ingredient>(ingredients); // Store original ingredients
        }

        public void Rescale(int option)
        {
            double scale;
            switch (option)
            {
                case 1:
                    scale = 0.5;
                    break;
                case 2:
                    scale = 1.0;
                    break;
                case 3:
                    scale = 2.0;
                    break;
                case 4:
                    scale = 3.0;
                    break;
                default:
                    Console.WriteLine("Invalid rescale option.");
                    return;
            }

            for (int i = 0; i < Ingredients.Count; i++)
            {
                // Scale based on original quantity
                Ingredients[i].Quantity = originalIngredients[i].Quantity * scale;
            }
        }

        public void ResetQuantity()
        {
            for (int i = 0; i < Ingredients.Count; i++)
            {
                // Revert to original quantity
                Ingredients[i].Quantity = originalIngredients[i].Quantity;
            }
        }

        public void SaveOriginalRecipe()
        {
            originalIngredients.Clear();
            originalIngredients.AddRange(Ingredients);
        }

        public void ClearOriginalRecipe()
        {
            originalIngredients.Clear();
        }

        public override string ToString()
        {
            string recipe = "Ingredients:\n";
            foreach (Ingredient ingredient in Ingredients)
            {
                recipe += $"{ingredient}\n";
            }

            recipe += "\nSteps:\n";
            for (int i = 0; i < Steps.Count; i++)
            {
                recipe += $"{i + 1}. {Steps[i]}\n";
            }

            return recipe;
        }
    }
}
