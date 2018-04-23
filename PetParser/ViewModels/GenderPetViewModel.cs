using PetParser.Models;
using System.Collections.Generic;

namespace PetParser.ViewModels
{
    public class GenderPetViewModel
    {
        public Sex Gender { get; set; }

        public IList<string> PetName { get; set; }

    }
}
