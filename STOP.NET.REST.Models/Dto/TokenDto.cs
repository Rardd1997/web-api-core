using Newtonsoft.Json;

namespace STOP.NET.REST.Models.Dto
{
    public class TokenDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
