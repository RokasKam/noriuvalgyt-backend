using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoriuValgyti.Domain.Entities;


namespace NoriuValgyti.Core.Requests.Recipe
{
    public class CreateRecipeRequest : IValidatableObject
    {
        [Required(ErrorMessage = "The name of the recipe must be chosen")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The photo of the place must be chosen")]
        [RegularExpression(@"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$",
      ErrorMessage = "The photo of the place must be valid")]
        public string? PhotoBase64 { get; set; }

        [Required(ErrorMessage = "The category of the recipe must be chosen")]
        [EnumDataType(typeof(Domain.Entities.Type), ErrorMessage = "The category of the place must be valid")]
        public Domain.Entities.Type Type { get; set; }

        [Required(ErrorMessage = "The description of the recipe must be written")]
        public string Description { get; set; }


        [Required(ErrorMessage = "The price of recipe must be written")]
        [Range(0, double.MaxValue, ErrorMessage = "The price cannot be negative")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "The minimum cooking time must be written")]
        [Range(0, int.MaxValue, ErrorMessage = "The minimum spent time of cooking cannot be negative")]
        public int DurationFrom { get; set; }

        [Required(ErrorMessage = "The maximum cooking time must be written")]
        [Range(0, int.MaxValue, ErrorMessage = "The maximum spent time of cooking cannot be negative")]
        public int DurationTo { get; set; }

        [Required(ErrorMessage = "The location of the place must be chosen")]
        [Range(0, int.MaxValue, ErrorMessage = "The number of calories cannot be negative")]
        public int Calories { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Type == Domain.Entities.Type.All)
            {
                yield return new ValidationResult("The category of the recipe must be chosen");

            }
            if (DurationFrom > DurationTo)
            {
                yield return new ValidationResult("The shortest cooking duration must be shorter or equal than the longest cooking duration");
            }
        }
    }
}