using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using NjordBooks.API.Data;
using History = NjordBooks.API.Models.History;

namespace NjordBooks.API.Controllers
{
    [Route( "[controller]" )]
    [ApiController]
    public class BankAccountHistoryController : ControllerBase
    {
        private readonly NjordBooksContext context;
        private readonly IConfiguration    configuration;

        public BankAccountHistoryController( NjordBooksContext context, IConfiguration configuration )
        {
            this.context       = context;
            this.configuration = configuration;
        }

        /// <summary>
        /// There is one Bank Account History record per day, per account, minimum.
        /// </summary>
        [HttpGet]
        public IEnumerable<History> Get( )
        {
            var rawData = this.context.CallPostgresFunction( "getallhistories" );

            return ( List<History> ) JsonConvert.DeserializeObject( rawData, typeof( List<History> ) );
        }
    }
}
