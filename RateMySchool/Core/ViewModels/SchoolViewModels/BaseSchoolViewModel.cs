using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Core.Interfaces;

namespace Core.ViewModels.SchoolViewModels
{
    public class BaseSchoolViewModel : IViewModel
    {
        [Required(ErrorMessage = "Name property is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City property is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Number property is required")]
        public int Number { get; set; }
    }
}