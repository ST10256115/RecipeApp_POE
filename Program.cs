using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
  public class Program
    {
        public delegate void CalorieNotification(string message);

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Recipe App!");
            ResetConsoleColor();

            var recipeBook = new RecipeBook();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Add new recipe");
                Console.WriteLine("2. Display recipes");
                Console.WriteLine("3. Exit");
                ResetConsoleColor();

                int option = GetValidatedIntegerInput("Enter option: ");

                switch (option)
                {
                    case 1:
                        AddNewRecipe(recipeBook);
                        break;
                    case 2:
                        DisplayRecipes(recipeBook);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please try again.");
                        ResetConsoleColor();
                        break;
                }
            }
        }

        private static void AddNewRecipe(RecipeBook recipeBook)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter recipe details:");
            ResetConsoleColor();

            Console.Write("Recipe name: ");
            string recipeName = Console.ReadLine();

            int ingredientCount = GetValidatedIntegerInput("Number of ingredients: ");

            List<Ingredient> ingredients = new List<Ingredient>();
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"\nIngredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                double quantity = GetValidatedDoubleInput("Quantity: ");
                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();
                double calories = GetValidatedDoubleInput("Calories: ");
                Console.Write("Food group: ");
                string foodGroup = Console.ReadLine();

                ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
            }

            int stepCount = GetValidatedIntegerInput("\nNumber of steps: ");

            List<string> steps = new List<string>();
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"\nStep {i + 1}:");
                Console.Write("What to do: ");
                steps.Add(Console.ReadLine());
            }

            var recipe = new Recipe(recipeName, ingredients, steps);
            recipeBook.AddRecipe(recipe);
        }

        private static void DisplayRecipes(RecipeBook recipeBook)
        {
            Console.Clear();
            var recipes = recipeBook.GetAllRecipes();
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes available.");
                ResetConsoleColor();
                return;
            }

            recipes = recipes.OrderBy(r => r.Name).ToList();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Recipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
            ResetConsoleColor();

            int recipeIndex = GetValidatedIntegerInput("Enter the number of the recipe to display: ") - 1;
            if (recipeIndex >= 0 && recipeIndex < recipes.Count)
            {
                var selectedRecipe = recipes[recipeIndex];
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Recipe: {selectedRecipe.Name}");
                Console.WriteLine(selectedRecipe);
                ResetConsoleColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid recipe number.");
                ResetConsoleColor();
            }
        }

        private static int GetValidatedIntegerInput(string prompt)
        {
            int result;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid input. Please enter a positive integer: ");
                ResetConsoleColor();
            }
            return result;
        }

        private static double GetValidatedDoubleInput(string prompt)
        {
            double result;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid input. Please enter a positive number: ");
                ResetConsoleColor();
            }
            return result;
        }

        private static void ResetConsoleColor()//reset color function newly added based on feedback
        {
            Console.ResetColor();
        }
    }
}
