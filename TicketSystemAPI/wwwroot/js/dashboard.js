
async function loadDashboard() {
    try {
        // 1. Consultar nuestra API
        const response = await fetch("/api/movies");

        if (!response.ok) {
            throw new Error("Error al consultar las películas");
        }

        // 2. Convertir la respuesta JSON
        const movies = await response.json();

        // 3. Actualizar indicadores
        document.getElementById("totalMovies")
            .textContent = movies.length;

        const genres = [...new Set(
            movies.map(movie => movie.genre)
        )];

        document.getElementById("totalGenres")
            .textContent = genres.length;

        const average = movies.length
            ? movies.reduce(
                (sum, movie) => sum + movie.duration, 0
            ) / movies.length
            : 0;

        document.getElementById("averageDuration")
            .textContent = average.toFixed(1) + " min";

        // 4. Agrupar películas por género
        const genreCounts = {};

        movies.forEach(movie => {
            genreCounts[movie.genre] =
                (genreCounts[movie.genre] || 0) + 1;
        });

        // 5. Crear gráfico de géneros
        new Chart(
            document.getElementById("genreChart"),
            {
                type: "doughnut",
                data: {
                    labels: Object.keys(genreCounts),
                    datasets: [{
                        label: "Películas",
                        data: Object.values(genreCounts),
                        backgroundColor: [
                            "#2563eb",
                            "#16a34a",
                            "#f59e0b",
                            "#a855f7"
                        ]
                    }]
                }
            }
        );

        // 6. Crear gráfico de duración
        new Chart(
            document.getElementById("durationChart"),
            {
                type: "bar",
                data: {
                    labels: movies.map(movie => movie.title),
                    datasets: [{
                        label: "Duración en minutos",
                        data: movies.map(movie => movie.duration),
                        backgroundColor: "#2563eb"
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            }
        );

    } catch (error) {
        console.error(error);

        document.getElementById("errorMessage")
            .textContent = "No fue posible cargar el dashboard.";
    }
}

loadDashboard();
