namespace TicketSystemAPI.DTOs
{
    public static class Movies
    {
        public static List<Movie> MovieList { get; } = new(){
            new Movie
            {
                Id = 1,
                Title= "Interstellar",
                Genre = "Science Fiction",
                Duration = 169
            },
            new Movie
            {
                Id = 2,
                Title = "Spider-Man",
                Genre = "Science Fiction",
                Duration = 149
            },
            new Movie{
                Id = 3,
                Title = "The Batman",
                Genre = "Action",
                Duration = 176
            }

        };   
    }
}
