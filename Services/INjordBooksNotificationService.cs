using System.Collections.Generic;
using System.Threading.Tasks;
using NjordBooks.API.Models;

namespace NjordBooks.API.Services
{
    public interface INjordBooksNotificationService
    {
        public Task NotifyOverdraft( string userId, BankAccount bankAccount );
        public Task<List<Notification>> GetNotificationsAsync( string userId );
    }
}
