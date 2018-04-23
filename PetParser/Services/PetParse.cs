using PetParser.Models;
using PetParser.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PetParser.Services
{
    public class PetParse : IPetParse
    {
        private IPetHttpHandler _httpHandler;
        private IList<Person> _rawResults;

        public PetParse(IPetHttpHandler httpHandler)
        {
            _httpHandler = httpHandler;
        }

        public async Task<IList<GenderPetViewModel>> ParsePetListAsync()
        {
            _rawResults = await _httpHandler.GetPetsAsync();
            return new List<GenderPetViewModel>
            {
                AddGenderPetModel(Sex.Male, PetType.Cat),
                AddGenderPetModel(Sex.Female, PetType.Cat)
            };
        }

        private GenderPetViewModel AddGenderPetModel(Sex gender, PetType pet)
        {
            return new GenderPetViewModel()
            {
                Gender = gender,
                PetName = _rawResults
                            .Where(x => x.Gender == gender)
                            .Where(x => x.Pets != null)
                                .SelectMany(x => x.Pets)
                                .Where(x => x.Type == pet)
                                .OrderBy(x => x.Name)
                                .Select(x => x.Name)
                                .ToList()
            };

        }
    }
}
