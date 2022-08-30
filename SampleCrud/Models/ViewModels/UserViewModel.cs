using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SampleCrud.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please add a name!")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Names length must be between 3 and 25 charachters ")]
        public string Name { get; set; } = null!;
        [Display(Name = "Personnel code")]
        [Required(ErrorMessage = "Please add a personnel code!")]
        [StringLength(11, MinimumLength = 6, ErrorMessage = "Personnel codes length must be between 6 and 11 charachters")]
        public string PersonnelCode { get; set; } = null!;
        [Display(Name = "Activation status")]
        public bool IsActive { get; set; }
    }
}
