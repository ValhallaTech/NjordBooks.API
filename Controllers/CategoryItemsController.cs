using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using NjordBooks.API.Data;
using CategoryItem = NjordBooks.API.Models.CategoryItem;

namespace NjordBooks.API.Controllers
{
    [Route( "[controller]")]
    [ApiController]
    public class CategoryItemsController : ControllerBase
    {
        private readonly NjordBooksContext     context;
        private readonly IConfiguration configuration;

        public CategoryItemsController(NjordBooksContext context, IConfiguration configuration)
        {
            this.context       = context;
            this.configuration = configuration;
        }

        /// <summary>
        /// Specific items within a budget group (category).
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CategoryItem> Get()
        {
            var rawData = this.context.CallPostgresFunction("getallcategoryitems");
            return (List<CategoryItem>)JsonConvert.DeserializeObject(rawData, typeof(List<CategoryItem>));
        }
    }
}
