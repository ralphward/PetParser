using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PetParser.Models
{
    public class Person
    {
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Sex Gender { get; set; }

        public int Age { get; set; }

        public IList<Pet> Pets { get; set; }
    }

    public enum Sex
    {
        Male,
        Female
    }
}
