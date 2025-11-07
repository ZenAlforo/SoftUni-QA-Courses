using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZippopotamusTesting
{
    public class Location
    {
        [JsonPropertyName("post code")]
        public string postCode { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("country abbreviation")]
        public string CountryAbbreviation { get; set; }

        [JsonPropertyName("places")]
        public List<Place> Places { get; set; }
    }
}