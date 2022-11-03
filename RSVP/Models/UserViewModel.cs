using System.ComponentModel.DataAnnotations;
using RSVP.Entities;

namespace RSVP.Models
{
    public class UserViewModel
    {
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select an option to indicate attendence.")]
        [EnumDataType(typeof(Attendence), ErrorMessage = "Attendence value doesn't exist in enum.")]
        public Attendence Attendence { get; set; } = Attendence.NotSure;
    }
}
