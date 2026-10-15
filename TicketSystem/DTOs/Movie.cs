namespace TicketSystem.DTOs
{
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public double vote_average { get; set; }

        public string PosterUrl
        {
            get
            {
                return $"https://image.tmdb.org/t/p/w500{poster_path}";
            }
        }

        public string PosterUrlLarge
        {
            get
            {
                return $"https://image.tmdb.org/t/p/w780{poster_path}";
            }
        }

    }
}
