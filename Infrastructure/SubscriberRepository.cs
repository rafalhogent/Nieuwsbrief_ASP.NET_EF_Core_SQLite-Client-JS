using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly SubscriberDbContext _context;

        public SubscriberRepository(SubscriberDbContext context)
        {
            _context = context;
            _ = _context.Database.EnsureCreated();
           
        }
        public async Task<Subscriber?> GetSubscriberByEmailAsync(string email)
        {
            return await _context.Subscribers.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<bool> AddNewSubscriberAsync(Subscriber subscriber)
        {
           await _context.Subscribers.AddAsync(subscriber);
           return await _context.SaveChangesAsync() > 0;  
        }


    }
}
