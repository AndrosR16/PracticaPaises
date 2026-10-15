using TicketSystemAPI.DTOs; 

var builder = WebApplication.CreateBuilder(args); 

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

//Aqui registraremos nuestros endpoints. 
app.MapGet("/api/movies", () =>
{
    return Results.Ok(Movies.MovieList);
});

app.MapGet("/api/movies/{id:int}", (int id) =>
{
    //lamda expressions
    var movie = Movies.MovieList.FirstOrDefault(x => x.Id == id);

    if(movie == null)
    {
        return Results.NotFound("Movie not found");
    }

    return Results.Ok(movie);
    
});

app.MapGet("api/movies/search", (string? title) =>
{
    if (string.IsNullOrWhiteSpace(title))
    {
        return Results.BadRequest("The title paramether is required");
    }

    //LinkQ
    var results = Movies.MovieList
        .Where(m => m.Title.Contains(title,StringComparison.OrdinalIgnoreCase)
    ).ToList();

    return Results.Ok(results);

}); 


app.MapPost("/api/movies", (Movie movie) =>
{

    if(
        string.IsNullOrWhiteSpace(movie.Title) || 
        string.IsNullOrWhiteSpace(movie.Genre) ||
        movie.Duration <= 0
    )
    {
        return Results.BadRequest("Title, Genre and a valid duration are required");
    }

    if(Movies.MovieList.Any(x => x.Id == movie.Id)) {
        return Results.Conflict("A movie with this ID already exits");
;   }

    Movies.MovieList.Add(movie);

    return Results.Created(
        $"/api/movies/{movie.Id}",
        movie);
 

});



app.Run(); 