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

        public AttendenceStats GetAttendenceStats()
        {
            var dbStats = _context.Users
                .GroupBy(u => u.Attendence)
                .Select(g => new { Attendence = g.Key, Count = g.Count() })
                .ToDictionary(g => g.Attendence, g => g.Count);

            var stats = new AttendenceStats()
            {
                WillAttend = dbStats[Attendence.Yes],
                WontAttend = dbStats[Attendence.No],
                MayAttend = dbStats[Attendence.NotSure]
            };
            return stats;
        }
    }
}
