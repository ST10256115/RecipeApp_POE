using System;
using System.Collections.Generic;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Recipe App!");

            Recipe recipe = null;
            bool recipeCreated = false;
            bool originalRecipeSaved = false;

            while (true)
            {
                if (!recipeCreated)
                {
                    Console.Clear(); // Clear the console when starting a new recipe
                    Console.WriteLine("Please enter recipe details:");

                    Console.Write("Number of ingredients: ");
                    int ingredientCount = int.Parse(Console.ReadLine());

                    List<Ingredient> ingredients = new List<Ingredient>();
                    for (int i = 0; i < ingredientCount; i++)
                    {
                        Console.WriteLine($"\nIngredient {i + 1}:");
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Quantity: ");
                        double quantity = double.Parse(Console.ReadLine());
                        Console.Write("Unit of measurement: ");
                        string unit = Console.ReadLine();

                        ingredients.Add(new Ingredient(name, quantity, unit));
                    }

                    Console.Write("\nNumber of steps: ");
                    int stepCount = int.Parse(Console.ReadLine());

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

                Console.WriteLine("\nRecipe details:");
                Console.WriteLine(recipe);

                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Rescale recipe");
                Console.WriteLine("2. Reset quantity");
                Console.WriteLine("3. Save original recipe");
                Console.WriteLine("4. Clear original recipe");
                Console.WriteLine("5. Clear recipe and start new");
                Console.WriteLine("6. Exit");

                Console.Write("Enter option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nRescale recipe:");
                        Console.WriteLine("1. Half");
                        Console.WriteLine("2. 1 person");
                        Console.WriteLine("3. 2 people");
                        Console.WriteLine("4. 3 people");
                        Console.Write("Enter option: ");
                        int rescaleOption = int.Parse(Console.ReadLine());
                        recipe.Rescale(rescaleOption);
                        Console.WriteLine("\nRescaled recipe details:");
                        Console.WriteLine(recipe);
                        break;
                    case 2:
                        recipe.ResetQuantity();
                        Console.WriteLine("\nQuantity reset to original values.");
                        Console.WriteLine("\nRecipe details:");
                        Console.WriteLine(recipe);
                        break;
                    case 3:
                        if (!originalRecipeSaved)
                        {
                            recipe.SaveOriginalRecipe();
                            Console.WriteLine("\nOriginal recipe saved.");
                            originalRecipeSaved = true;
                        }
                        else
                        {
                            Console.WriteLine("\nOriginal recipe is already saved.");
                        }
                        break;
                    case 4:
                        recipe.ClearOriginalRecipe();
                        Console.WriteLine("\nOriginal recipe cleared.");
                        originalRecipeSaved = false; // Ensure original recipe is not saved after clearing
                        break;
                    case 5:
                        Console.Clear(); // Clear the console when starting a new recipe
                        recipeCreated = false;
                        originalRecipeSaved = false; // Ensure original recipe is not saved when starting a new recipe
                        Console.WriteLine("\nRecipe cleared and ready for new recipe.");
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
