using System.Collections.Generic;
using System.Threading.Tasks;
using PetParser.ViewModels;

namespace PetParser.Services
{
    public interface IPetParse
    {
        Task<IList<GenderPetViewModel>> ParsePetListAsync();
    }
}
