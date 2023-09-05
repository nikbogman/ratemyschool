using Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class ReportModel : IModel
    {
        [Required(ErrorMessage = "Content of review shoud be provided for creation")]
        public string Reason { get; set; }
        public Guid ReviewId { get; set; }
    }
}
