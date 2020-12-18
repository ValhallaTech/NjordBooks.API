using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Newtonsoft.Json;
using NjordBooks.API.Data;
using BankAccount = NjordBooks.API.Models.BankAccount;

namespace NjordBooks.API.Controllers
{
    [Route( "[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly NjordBooksContext     context;
        private readonly IConfiguration configuration;

        public BankAccountsController(NjordBooksContext context, IConfiguration configuration)
        {
            this.context       = context;
            this.configuration = configuration;
        }

        /// <summary>
        /// Bank accounts are grouped by households, not individuals.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BankAccount> Get()
        {
            var rawData = this.context.CallPostgresFunction("getallbankaccounts");
            return (List<BankAccount>)JsonConvert.DeserializeObject(rawData, typeof(List<BankAccount>));
        }
    }
}
