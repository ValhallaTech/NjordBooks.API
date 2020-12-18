using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using NjordBooks.API.Data;
using Transaction = NjordBooks.API.Models.Transaction;

namespace NjordBooks.API.Controllers
{
    [Route( "[controller]" )]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly NjordBooksContext context;
        private readonly IConfiguration    configuration;

        public TransactionsController( NjordBooksContext context, IConfiguration configuration )
        {
            this.context       = context;
            this.configuration = configuration;
        }

        /// <summary>
        /// Transactions are either of type withdrawal or deposit, and track how much you spend on an item within a budget (category).
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Transaction> Get( )
        {
            var rawData = this.context.CallPostgresFunction( "getalltransactions" );

            return ( List<Transaction> ) JsonConvert.DeserializeObject( rawData, typeof( List<Transaction> ) );
        }
    }
}
