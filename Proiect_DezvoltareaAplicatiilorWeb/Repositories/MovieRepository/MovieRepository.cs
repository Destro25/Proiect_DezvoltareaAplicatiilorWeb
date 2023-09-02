using Proiect_DezvoltareaAplicatiilorWeb.Data;
using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.GenericRepository;

namespace Proiect_DezvoltareaAplicatiilorWeb.Repositories.MovieRepository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ProjectContext projectContext) : base(projectContext) { }
        
        public Movie GetMovieByName(string mName)
        {
            return _table.FirstOrDefault(x => x.MovieName == mName);
        }

        public List<Movie> GetMoviesByStudio(string studio)
        {
            var movies = _table.Where(m => m.StudioName.ToLower().Equals(studio.ToLower())).ToList();
            return movies;
        }
    }
}
