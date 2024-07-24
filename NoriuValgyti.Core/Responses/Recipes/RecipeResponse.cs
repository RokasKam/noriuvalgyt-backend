using NoriuValgyti.Domain.Entities;
using Type = NoriuValgyti.Domain.Entities.Type;

namespace NoriuValgyti.Core.Responses.Recipes
{
    public class RecipeResponse
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
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
