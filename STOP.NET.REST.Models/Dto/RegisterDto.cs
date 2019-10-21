using Newtonsoft.Json;

namespace STOP.NET.REST.Models.Dto
{
    public class RegisterDto
    {
        [JsonProperty(PropertyName = "name")]
        [JsonRequired]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        [JsonRequired]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        [JsonRequired]
        public string Password { get; set; }
    }
}
