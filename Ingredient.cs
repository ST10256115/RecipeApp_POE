﻿namespace RecipeApp
{
    public class Ingredient//class to store ingredients data
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name} ({Calories} calories, {FoodGroup})";
        }
    }
}
