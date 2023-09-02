using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.GenericRepository;

namespace Proiect_DezvoltareaAplicatiilorWeb.Repositories.MovieRepository
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        public Movie GetMovieByName(string mName);
        public List<Movie> GetMoviesByStudio(string studio);
    }
}
