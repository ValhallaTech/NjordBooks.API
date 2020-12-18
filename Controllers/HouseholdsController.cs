using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using NjordBooks.API.Data;
using Household = NjordBooks.API.Models.Household;

namespace NjordBooks.API.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class HouseholdsController : ControllerBase
    {
        private readonly NjordBooksContext context;
        private readonly IConfiguration    configuration;

        public HouseholdsController( NjordBooksContext context, IConfiguration configuration )
        {
            this.context       = context;
            this.configuration = configuration;
        }

        /// <summary>
        /// A household is an umbrella group which contains users, categories, items, and transactions.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallhouseholds")]
        public IEnumerable<Household> GetAllHouseholds( )
        {
            var rawData = this.context.CallPostgresFunction( "getallhouseholds" );

            return ( List<Household> )JsonConvert.DeserializeObject( rawData, typeof( List<Household> ) );
        }
    }
}
