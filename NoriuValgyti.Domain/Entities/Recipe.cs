using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoriuValgyti.Domain.Entities
{
    public enum Type
    {
        Vegan,
        Vegetarian,
        Dessert,
        Meat,
        Breakfast,
        Soup,
        Children,
        High_Protein,
        Snack,
        Beverage,
        None,
        All
    }
    public class Recipe: BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Type Type { get; set; }
        public int Calories { get; set; }
        public int DurationFrom { get; set; }
        public int DurationTo { get; set; }
        public decimal Cost { get; set; }
        public string? PhotoURL { get; set; }
        public double Rating { get; set; }
        public int RatingAmount { get; set; }
    }
}
