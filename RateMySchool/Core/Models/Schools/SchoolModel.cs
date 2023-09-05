using System.ComponentModel.DataAnnotations;
using Core.Interfaces;

namespace Core.Models.Schools
{
    public abstract class SchoolModel : IModel
    {
        [Required(ErrorMessage = "Name property is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City property is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Number property is required")]
        public int Number { get; set; }
    }
}