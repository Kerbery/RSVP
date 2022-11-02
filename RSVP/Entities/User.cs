using System.ComponentModel.DataAnnotations;

namespace RSVP.Entities
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public Attendence Attendence { get; set; } = Attendence.NotSure;
    }
}
