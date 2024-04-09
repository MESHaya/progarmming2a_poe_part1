using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecipeApp
{
    /// <summary>
    /// This class is where all methods relating to the recipe
    ///such as delete,clear etc will be 
    /// </summary>
    public class Recipe
    {
        /// <summary>
        ///  declear and initialise all variables including the arrays 
        /// </summary>
        private Ingridients[] ingridients = [];
        private Steps[] steps = [];
        private double scale_factor = 1;
        private int snum = 0;
        private string description = " ";
        private string recipeName = "";
        private int inum = 0;
        private string IName = "";
        private int quantity = 0;
        private string uom = " ";
        private int uomChoice = 0;
        private int Choice = 0;
        private bool valid = false;
        /// <summary>
        /// This method is responsible for displaying the Recipe and the menu 
        /// </summary>
        public void DisplayRecipe()
        {
            GetRecipeName();
            GetIngredients();
            GetSteps();
            Display.DisplayRecipeDetails(ingridients, steps, recipeName, scale_factor);
            Menu();
        }

        /// <summary>
        /// This method is responsible for getting the name of 
        /// the recipe form the user. 
        /// This method also includes error handline from the subconsole
        /// </summary>
        private void GetRecipeName()
        {
            while (!valid)
            {
                Console.Write("Enter name of recipe: ");
                recipeName = Console.ReadLine() ?? "";
                if (recipeName == "")
                {
                    SubConsole.LogErr("Enter a valid Recipe Name", 2000);
                }
                else
                {
                    valid = true;
                }
            }
            Console.Clear();
        }

        /// <summary>
        /// This method is responsible for getting ingrideients including 
        /// name, quantity and uom. We then add the ingrideint into the 
        /// array Ingridients. 
        /// </summary>
        private void GetIngredients()
        {
            GetNumIngredients();
            Console.Clear();
            ingridients = new Ingridients[inum];

            for (int i = 0; i < inum; i++)
            {
                GetIngredientName();
                Console.Clear();

                GetUoM();

                GetIngQuantity();
                Console.Clear();

                //create object and store it in array 
                ingridients[i] = new Ingridients(quantity, uom, IName);
            }
            Console.Clear();
        }
        #region Ingredient Helper Methods

        /// <summary>
        /// These methods assist the GetIngridients() method, we get the steps, quantity and uom
        /// These methods includes exception handling. 
        /// </summary>
        private void GetNumIngredients()
        {
            valid = false;
            while (!valid)
            {
                inum = SubConsole.GetIntIn("Enter number of ingridients: ");
                if (inum == -1)
                {
                    SubConsole.LogErr("Enter a valid Number!", 2000);
                }
                else
                {
                    valid = true;
                }
            }
        }

        /// <summary>
        /// Gets the ingredient name as user input
        /// </summary>
        private void GetIngredientName()
        {
            IName = "";
            valid = false;
            while (!valid)
            {
                Console.Write("Enter ingredient Name: ");
                IName = Console.ReadLine() ?? "";
                if (IName == "")
                {
                    SubConsole.LogErr("Enter a valid ingredient Name", 2000);
                }
                else
                {
                    valid = true;
                }
            }
        }

        private void GetUoM()
        {
            valid = false;
            while (!valid)
            {
                uomChoice = SubConsole.GetIntIn("1 - Cup\n2 - Tsp\n3 - Tbsp\n4 - L\n5 - Ml\n6 - g\n7 - kg\n 8 - none \n Choose Unit of Measurment: ");
                if (inum == -1)
                {
                    SubConsole.LogErr("Enter a valid Number!", 2000);
                }
                else
                {
                    valid = true;
                }
            }
            Console.Clear();
            switch (uomChoice)
            {
                case 1:
                    uom = "Cup";
                    break;
                case 2:
                    uom = "Teaspoon";
                    break;
                case 3:
                    uom = "Tablespoon";
                    break;
                case 4:
                    uom = "Litre";
                    break;
                case 5:
                    uom = "Mililitre";
                    break;
                case 6:
                    uom = "Gram";
                    break;
                case 7:
                    uom = "Kilogram";
                    break;
                case 8:
                    uom = " ";
                    break;
                case 9:
                    uom = "unknown";
                    break;

            }
        }

        private void GetIngQuantity()
        {
            valid = false;
            while (!valid)
            {
                quantity = SubConsole.GetIntIn("Enter Quantity: ");
                if (quantity == -1)
                {
                    SubConsole.LogErr("Enter a valid Number!", 2000);
                }
                else
                {
                    valid = true;
                }
            }
        }
        #endregion

        /// <summary>
        /// This method is responsible for getting the steps including 
        /// number of steps as well as the description, and adding it to the Steps array 
        /// This method has exception handling from the subconsole. 
        /// </summary>
        private void GetSteps()
        {
            valid = false;
            while (!valid)
            {
                snum = SubConsole.GetIntIn("Enter the number of steps: ");
                if (snum == -1)
                {
                    SubConsole.LogErr("Enter a valid Number!", 2000);
                }
                else
                {
                    valid = true;
                }
            }
            Console.Clear();

            steps = new Steps[snum];

            Console.WriteLine("Describe each step: ");
            for (int i = 0; i < snum; i++)
            {
                valid = false;
                while (!valid)
                {
                    Console.Write($"Enter step {i + 1}: ");
                    description = Console.ReadLine() ?? "";
                    if (recipeName == "")
                    {
                        SubConsole.LogErr("Enter a valid step", 2000);
                    }
                    else
                    {
                        valid = true;
                    }
                }
                steps[i] = new Steps(description);
            }

            Console.Clear();
        }

        /// <summary>
        /// This method is responsible for the menu funtionality. We use a switch case 
        /// as well as exception handling to get our working menu. This method is where 
        /// the functionality for scale,reset,clear and exit are done. 
        /// </summary>
        private void Menu()
        {
            bool finished = false;
            while (!finished)
            {
                Display.DisplayRecipeDetails(ingridients, steps, recipeName, scale_factor);
                valid = false;
                while (!valid)
                {
                    Choice = SubConsole.GetIntIn(
                        "1 - Scale Recipe\n" + "2 - Reset Recipe\n" + "3 - Clear Recipe\n" + "4 - Exit\n" + "Select Option: "
                    );
                    if (Choice == -1)
                    {
                        SubConsole.LogErr("Enter a valid Option!", 2000);
                    }
                    else
                    {
                        valid = true;
                    }
                }
                Console.Clear();
                switch (Choice)
                {
                    case 1: // Scale Recipe



                        Console.WriteLine("Enter scale factor(0.5 for halving, 2 for doubling, 3 for tripling");
                        scale_factor =Convert.ToDouble( Console.ReadLine()); 
                            
                           
                        
                        break;
                    case 2: // Reset Recipe. This is done by resetting scale_factor to 1 
                        scale_factor = 1; 
                        Console.Clear();
                        break;
                    case 3: // Clear Recipe. This is done by assigning an empty array 
                        ingridients = [];
                        steps = [];

                        Console.Clear();
                        break;
                    case 4: // Exit
                        finished = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}