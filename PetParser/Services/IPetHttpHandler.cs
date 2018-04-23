using PetParser.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetParser.Services
{
    public interface IPetHttpHandler
    {
        Task<IList<Person>> GetPetsAsync();
    }
}