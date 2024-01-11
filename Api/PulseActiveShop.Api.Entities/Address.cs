using System.Text.Json.Serialization;

namespace PulseActiveShop.Api.Entities
{
    public class Address
    {
        [JsonPropertyName("street")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Street { get; set; }

        [JsonPropertyName("city")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? City { get; set; }

        [JsonPropertyName("stateOrProvince")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StateOrProvince { get; set; }

        [JsonPropertyName("country")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Country { get; set; }

        [JsonPropertyName("zipCode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ZipCode { get; set; }
    }
}
