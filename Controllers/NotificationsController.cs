using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using NjordBooks.API.Data;
using Notification = NjordBooks.API.Models.Notification;

namespace NjordBooks.API.Controllers
{
    [Route( "[controller]" )]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly NjordBooksContext context;
        private readonly IConfiguration    configuration;

        public NotificationsController( NjordBooksContext context, IConfiguration configuration )
        {
            this.context       = context;
            this.configuration = configuration;
        }

        /// <summary>
        /// Notifications are records (emails) that are sent to the head of household.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Notification> Get( )
        {
            var rawData = this.context.CallPostgresFunction( "getallnotifications" );

            return ( List<Notification> ) JsonConvert.DeserializeObject( rawData, typeof( List<Notification> ) );
        }
    }
}
