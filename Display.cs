using RecipeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    /// <summary>
    /// provides methods for displaying recipe details 
    /// </summary>
    public static class Display
    {
        /// <summary>
        /// Displays the details of a recipe including ingredients and steps.
        /// </summary>
        /// <param name="ingredients">An array of Ingredients objects representing the ingredients of the recipe.</param>
        /// <param name="steps">An array of Steps objects representing the steps of the recipe.</param>
        /// <param name="recipeName">The name of the recipe.</param>
        /// <param name="scale_factor">The scaling factor for adjusting ingredient quantities.</param>
        public static void DisplayRecipeDetails(Ingridients[] ingredients, Steps[] steps, string recipeName, double scale_factor)
        {
            //Display Recipe
            Console.WriteLine("Recipe Name: " + "\n" + recipeName);

            Console.WriteLine("---Ingridients---");
            foreach (var ingridiend in ingredients)
            {
                Console.WriteLine(ingridiend.quantity * scale_factor + " " + ingridiend.uom + " of " + ingridiend.IName);
            }

            Console.WriteLine("---Steps---");
            for (int s = 0; s < steps.Length; s++)
            {
                Console.WriteLine($" Step: {s + 1} : {steps[s].description}");
            }
        }
    }
}