using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using NjordBooks.API.Data;
using Category = NjordBooks.API.Models.Category;

namespace NjordBooks.API.Controllers
{
    [Route( "[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly NjordBooksContext     context;
        private readonly IConfiguration configuration;

        public CategoriesController(NjordBooksContext context, IConfiguration configuration)
        {
            this.context       = context;
            this.configuration = configuration;
        }

        /// <summary>
        /// A budget group
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var rawData = this.context.CallPostgresFunction("getallcategories");
            return (List<Category>)JsonConvert.DeserializeObject(rawData, typeof(List<Category>));
        }
    }
}
