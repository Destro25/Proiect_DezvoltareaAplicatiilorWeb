using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;

namespace Proiect_DezvoltareaAplicatiilorWeb.Services.MovieService
{
    public interface IMovieService
    {
        Task Create(MovieDTO movie);
        Task Delete(Guid Id);
        Task<List<Movie>> GetAll();
        Task<Movie> GetById (Guid id);
        Task<Movie>? Update(Guid Id, MovieDTO movie);

        List<Movie> GetByStudio(string Studio);
    }
}
