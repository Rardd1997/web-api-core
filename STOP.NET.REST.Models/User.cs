using Newtonsoft.Json;
using System.Collections.Generic;

namespace STOP.NET.REST.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        [JsonIgnore]
        public virtual Credentials Credentials { get; set; }

        [JsonIgnore]
        public virtual IList<Account> Accounts { get; set; }
    }
}
