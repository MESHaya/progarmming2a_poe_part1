using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    /// <summary>
    /// This class is where the constructors for Steps will be 
    /// </summary>
    public class Steps
    {
        
        public string description { get; set; }
        public Steps(string description)
        {
            this.description = description;
        }
    }
}