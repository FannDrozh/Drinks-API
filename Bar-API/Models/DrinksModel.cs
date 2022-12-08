using Bar_API.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Bar_API.Models
{
    public class DrinksModel
    {
        public DrinksModel (Drinks drinks) 
        {
            ID_Drink = drinks.ID_Drink;
            Name = drinks.Name;
            Price = (int)drinks.Price;
            Image = drinks.Image;
        }
        public int ID_Drink { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}