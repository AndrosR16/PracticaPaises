using System.Text.Json;
using TicketSystem.DTOs;

namespace TicketSystem.Services
{
    public class CountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Country>> GetCountries()
        {
            var response = await _httpClient.GetAsync(
                "https://countries.dev/countries"
            );

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new List<Country>();
            }

            var countries = JsonSerializer.Deserialize<List<Country>>(json);

            return countries ?? new List<Country>();
        }

        public async Task<Country?> GetCountryByCode(string code)
        {
            var response = await _httpClient.GetAsync(
                $"https://countries.dev/alpha/{code}"
            );

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var country = JsonSerializer.Deserialize<Country>(json);

            return country;
        }
    }
}