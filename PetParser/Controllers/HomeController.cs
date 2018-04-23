using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetParser.Services;

namespace PetParser.Controllers
{
    public class HomeController : Controller
    {
        private IPetParse _petParse;

        public HomeController(IPetParse petParse)
        {
            _petParse = petParse;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _petParse.ParsePetListAsync();            

            return View(results);
        }
    }
}