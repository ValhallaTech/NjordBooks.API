using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using NjordBooks.API.Data;
using Invitation = NjordBooks.API.Models.Invitation;

namespace NjordBooks.API.Controllers
{
    [Route( "[controller]" )]
    [ApiController]
    public class InvitationsController : ControllerBase
    {
        private readonly NjordBooksContext context;
        private readonly IConfiguration    configuration;

        public InvitationsController( NjordBooksContext context, IConfiguration configuration )
        {
            this.context       = context;
            this.configuration = configuration;
        }

        /// <summary>
        /// Invitations are records (emails) that are sent to others by the head of the household.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Invitation> Get( )
        {
            var rawData = this.context.CallPostgresFunction( "getallinvitations" );

            return ( List<Invitation> ) JsonConvert.DeserializeObject( rawData, typeof( List<Invitation> ) );
        }
    }
}
