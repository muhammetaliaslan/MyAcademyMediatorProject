using System;
using System.Threading.Tasks;
using MyAcademyMediatorProject.Context;
using MyAcademyMediatorProject.Entities;

namespace MyAcademyMediatorProject.Patterns.Observer
{
    public class ContactLogObserver : IContactObserver
    {
        private readonly AppDbContext _context;

        public ContactLogObserver(AppDbContext context)
        {
            _context = context;
        }

        public async Task NotifyAsync(string name, string email, string message)
        {
            var log = new Log
            {
                ActionType = "ContactMessage",
                Description = $"Name: {name}, Email: {email}, Message: {message}",
                CreatedDate = DateTime.UtcNow
            };

            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}