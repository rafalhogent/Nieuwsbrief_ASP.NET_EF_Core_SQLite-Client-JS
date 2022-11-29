using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISubscriberRepository
    {
        Task<bool> AddNewSubscriberAsync(Subscriber subscriber);
        Task<Subscriber?> GetSubscriberByEmailAsync(string email);
    }
}
