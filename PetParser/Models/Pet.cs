using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PetParser.Models
{

    public class Pet
    {
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PetType Type { get; set; }
    }

    public enum PetType
    {
        Cat,
        Dog,
        Fish
    }

}
