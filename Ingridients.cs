using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    /// <summary>
    /// Represents an ingridient used in the recipe
    /// </summary>
    public class Ingridients
    {
        /// <summary>
        /// gets or sets the quantity,uom and name or an ingridient
        /// </summary>
        public int quantity { get; set; }
        public string uom { get; set; }
        public string IName { get; set; }

        //constructors 
        /// <summary>
        /// initialises an new instance of ingridient using all paramenters 
        /// </summary>
        /// <param name="quantity">the quantity of an ingridient</param>
        /// <param name="uom">the uom of an ingridient</param>
        /// <param name="IName">the name of an ingridient</param>
        public Ingridients(int quantity, string uom, string IName)
        {
            this.quantity = quantity;
            this.uom = uom;
            this.IName = IName;
        }
    }
}