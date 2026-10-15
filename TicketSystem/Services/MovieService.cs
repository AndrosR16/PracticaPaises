using System.Net.Http.Headers;
using System.Text.Json;
using TicketSystem.DTOs; 

namespace TicketSystem.Services
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService()
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4MTQ4MDM0N2E0NDZjNjJlZjQwYjI3NjUxZjNjYjEwYyIsIm5iZiI6MTc5MDkyMjU1OS40MTgsInN1YiI6IjZhYmY0ZjNmNGFmYmI0ZWEzMmQ3NmNhYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.4LUIPmXgyRA1zyKoh6kRizMYpbzi7iHeyS48zqe2GpY");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 

        }

        public async Task<List<Movie>> GetMovies()
        {
            var response = await _httpClient.GetAsync("https://api.themoviedb.org/3/movie/popular?language=en-US&page=1"); 

            var json = await response.Content.ReadAsStringAsync();

            if(!response.IsSuccessStatusCode)
            {
                return new List<Movie>(); 
            }

            var movieResponse = JsonSerializer.Deserialize<Movies>(json);

            return movieResponse?.results ?? new List<Movie>();

        }

        public async Task<Movie?> GetMovieById(int id)
        {
            var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/{id}?language=en-US");

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var movie = JsonSerializer.Deserialize<Movie>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive= true,
                });

            return movie; 
        }

    }
}
