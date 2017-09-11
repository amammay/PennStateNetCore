﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PsuApi;
using PsuApi.Models;

namespace AngularNetCore2.Controllers
{
    [Route("api/[controller]")]
    public class PennStateController : Controller
    {
        // POST api/PennState
        /// <summary>
        ///     Uses the form body to get applicable information
        /// </summary>
        /// <param name="json"></param>
        /// <returns> Json object of the search result</returns>
        [HttpPost]
        public async Task<IEnumerable<PsuSearchResult>> Post([FromBody] JObject json)
        {
            var psuClient = new PsuSearchClient();
            var searchObject = json.ToObject<SearchForm>();

            switch (searchObject.Full)
            {
                case PsuSearchEnum.Short:
                    return await psuClient.PostRetrieveShort(searchObject);
                //case PsuSearchEnum.Long:
                //    return await psuClient.PostRetrieveLong(searchObject);
                default:
                    return null;

            }

        }
    }
}