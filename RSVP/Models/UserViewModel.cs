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
        public Attendence Attendence { get; set; } = Attendence.NotSure;
    }
}
