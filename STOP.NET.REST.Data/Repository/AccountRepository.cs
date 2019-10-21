using STOP.NET.REST.Data.Context;
using STOP.NET.REST.Models;

namespace STOP.NET.REST.Data.Repository
{
    public class AccountRepository : DataRepository<Account>
    {
        public AccountRepository(RESTContext context) : base(context) { }
    }
}
