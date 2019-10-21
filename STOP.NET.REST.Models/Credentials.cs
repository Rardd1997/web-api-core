using Newtonsoft.Json;

namespace STOP.NET.REST.Models
{
    public class Credentials : BaseModel
    {
        public string Password { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        public string UserId { get; set; }
    }
}
