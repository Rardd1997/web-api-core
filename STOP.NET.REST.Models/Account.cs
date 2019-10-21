using Newtonsoft.Json;

namespace STOP.NET.REST.Models
{
    public class Account : BaseModel
    {
        public string AuthorizationCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhotoHash { get; set; }
        public AccountTypeEnum Type { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        public string UserId { get; set; }
    }
}
