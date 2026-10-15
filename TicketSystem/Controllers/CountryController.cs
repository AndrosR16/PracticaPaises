using Microsoft.AspNetCore.Mvc;
using TicketSystem.DTOs;
using TicketSystem.Services;

namespace TicketSystem.Controllers
{
    public class CountryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            CountryService countryService = new CountryService();

            var countries = await countryService.GetCountries();

            return View(countries);
        }

        public async Task<IActionResult> Details(string id)
        {
            CountryService countryService = new CountryService();

            var country = await countryService.GetCountryByCode(id);

            if (country == null)
            {
                return NotFound();
            }

            List<Country> borderCountries = new List<Country>();

            if (country.borders != null)
            {
                foreach (var border in country.borders)
                {
                    var borderCountry = await countryService.GetCountryByCode(border);

                    if (borderCountry != null)
                    {
                        borderCountries.Add(borderCountry);
                    }
                }
            }

            ViewBag.BorderCountries = borderCountries;

            return View(country);
        }
    }
}