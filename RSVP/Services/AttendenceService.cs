using RSVP.Data;
using RSVP.Entities;
using RSVP.Models;

namespace RSVP.Services
{
    public class AttendenceService : IAttendenceService
    {
        private readonly AttendenceContext _context;

        public AttendenceService(AttendenceContext context)
        {
            _context = context;
        }

        public void AddUser(UserViewModel userViewModel)
        {
            var user = new User()
            {
                Name = userViewModel.Name,
                Surname = userViewModel.Surname,
                Attendence = userViewModel.Attendence
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
