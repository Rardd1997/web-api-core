using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using STOP.NET.REST.Models;

namespace STOP.NET.REST.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountTypesController
    {
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            var type = new JObject();

            foreach (var item in Enum.GetValues(typeof(AccountTypeEnum)))
            {
                type[Enum.GetName(typeof(AccountTypeEnum), item)] = (int)item;
            }
            
            return type.ToString();
        }
    }
}
