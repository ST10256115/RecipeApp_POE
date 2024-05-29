using System;
using System.Collections.Generic;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Recipe App!");
            ResetConsoleColor();

            Recipe recipe = null;
            bool recipeCreated = false;
            bool originalRecipeSaved = false;

            while (true)
            {
                if (!recipeCreated)
                {
                    Console.Clear(); // Clear the console when starting a new recipe
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter recipe details:");
                    ResetConsoleColor();

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

                        ingredients.Add(new Ingredient(name, quantity, unit));
                    }

                    int stepCount = GetValidatedIntegerInput("\nNumber of steps: ");

                    List<string> steps = new List<string>();
                    for (int i = 0; i < stepCount; i++)
                    {
                        Console.WriteLine($"\nStep {i + 1}:");
                        Console.Write("What to do: ");
                        steps.Add(Console.ReadLine());
                    }

                    recipe = new Recipe(ingredients, steps);
                    recipeCreated = true;
                    originalRecipeSaved = false; // Ensure original recipe is not saved when starting a new recipe
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nRecipe details:");
                Console.WriteLine(recipe);
                ResetConsoleColor();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Rescale recipe");
                Console.WriteLine("2. Reset quantity");
                Console.WriteLine("3. Save original recipe");
                Console.WriteLine("4. Clear original recipe");
                Console.WriteLine("5. Clear recipe and start new");
                Console.WriteLine("6. Exit");
                ResetConsoleColor();

                int option = GetValidatedIntegerInput("Enter option: ");

                switch (option)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nRescale recipe:");
                        Console.WriteLine("1. Half");
                        Console.WriteLine("2. 1 person");
                        Console.WriteLine("3. 2 people");
                        Console.WriteLine("4. 3 people");
                        int rescaleOption = GetValidatedIntegerInput("Enter option: ");
                        recipe.Rescale(rescaleOption);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nRescaled recipe details:");
                        Console.WriteLine(recipe);
                        ResetConsoleColor();
                        break;
                    case 2:
                        recipe.ResetQuantity();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nQuantity reset to original values.");
                        Console.WriteLine("\nRecipe details:");
                        Console.WriteLine(recipe);
                        ResetConsoleColor();
                        break;
                    case 3:
                        if (!originalRecipeSaved)
                        {
                            recipe.SaveOriginalRecipe();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nOriginal recipe saved.");
                            originalRecipeSaved = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nOriginal recipe is already saved.");
                        }
                        ResetConsoleColor();
                        break;
                    case 4:
                        recipe.ClearOriginalRecipe();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nOriginal recipe cleared.");
                        originalRecipeSaved = false; // Ensure original recipe is not saved after clearing
                        ResetConsoleColor();
                        break;
                    case 5:
                        Console.Write("\nAre you sure you want to clear the recipe and start a new one? (yes/no): ");
                        string confirmation = Console.ReadLine().Trim().ToLower();
                        if (confirmation == "yes" || confirmation == "y")
                        {
                            Console.Clear(); // Clear the console when starting a new recipe
                            recipeCreated = false;
                            originalRecipeSaved = false; // Ensure original recipe is not saved when starting a new recipe
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nRecipe cleared and ready for new recipe.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nClear recipe operation canceled.");
                        }
                        ResetConsoleColor();
                        break;
                    case 6:
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

        private static void ResetConsoleColor()
        {
            Console.ResetColor();
        }
    }
}
