using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using NjordBooks.API.Data;
using NjordBooksUser = NjordBooks.API.Models.NjordBooksUser;

namespace NjordBooks.API.Controllers
{
    [Route( "[controller]" )]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly NjordBooksContext context;
        private readonly IConfiguration    configuration;

        public UsersController( NjordBooksContext context, IConfiguration configuration )
        {
            this.context       = context;
            this.configuration = configuration;
        }

        /// A user extends microsoft's identity user and adds a few properties such as first and last name, as well as a display name.
        [HttpGet]
        public IEnumerable<NjordBooksUser> Get( )
        {
            var rawData = this.context.CallPostgresFunction( "getallusers" );

            return ( List<NjordBooksUser> ) JsonConvert.DeserializeObject( rawData, typeof( List<NjordBooksUser> ) );
        }
    }
}
