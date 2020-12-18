using System.Collections.Generic;
using System.Threading.Tasks;
using NjordBooks.API.Models;

namespace NjordBooks.API.Services
{
    public interface INjordBooksHouseholdService
    {
        public Task<List<NjordBooksUser>> ListHouseHoldMembersAsync( int? houseHoldId );
        public Task<string> GetRoleAsync( NjordBooksUser user );
        public List<Transaction> ListTransactions( Household houseHold );
        public Task<string> GetGreetingAsync( NjordBooksUser user );
    }
}
