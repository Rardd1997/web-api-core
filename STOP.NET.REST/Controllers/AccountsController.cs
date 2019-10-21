using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STOP.NET.REST.Data.Repository;
using STOP.NET.REST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STOP.NET.REST.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IDataRepository<Account> _repository;

        public AccountsController(IDataRepository<Account> repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return _repository.FindAll().ToList();
        }

        // GET api/<controller>/GUID
        [HttpGet("{id}")]
        public Account Get(string id)
        {
            return _repository.Lookup(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Account value)
        {
            _repository.Insert(value);
            _repository.SaveChanges();
        }

        // PUT api/<controller>
        [HttpPut]
        public void Put([FromBody]Account value)
        {
            _repository.Update(value);
            _repository.SaveChanges();
        }

        // DELETE api/<controller>/GUID
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var entity = _repository.Lookup(id);
            _repository.Delete(entity);
        }
    }
}
