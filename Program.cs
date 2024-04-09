using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace RecipeApp

{
    public class App
    {
        /// <summary>
        /// The entry point of the RecipeApp application.
        /// Initializes a new Recipe object and displays its details.
        /// </summary>
        /// <param name="args">The command line arguments</param>
        public static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            recipe.DisplayRecipe();
        }
    }

}
