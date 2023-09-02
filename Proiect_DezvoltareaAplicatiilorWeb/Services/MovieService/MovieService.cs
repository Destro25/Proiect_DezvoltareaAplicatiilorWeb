using AutoMapper;
using Proiect_DezvoltareaAplicatiilorWeb.Models;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.UnitOfWork;

namespace Proiect_DezvoltareaAplicatiilorWeb.Services.MovieService
{
    public class MovieService : IMovieService
    {
        public IMapper Mapper;
        public IUnitOfWork UnitOfWork;

        public MovieService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task Create(MovieDTO movie)
        {
            var mov = Mapper.Map<Movie>(movie);
            await UnitOfWork.movieRepository.CreateAsync(mov);
            await UnitOfWork.movieRepository.SaveAsync();
        }

        public async Task Delete(Guid Id)
        {
            var mov = await UnitOfWork.movieRepository.FindByIdAsync(Id);
            UnitOfWork.movieRepository.Delete(mov);
            await UnitOfWork.movieRepository.SaveAsync();
        }

        public async Task<List<Movie>> GetAll()
        {
            return await UnitOfWork.movieRepository.GetAll();
        }

        public async Task<Movie> GetById(Guid Id)
        {
            return await UnitOfWork.movieRepository.FindByIdAsync(Id);
        }

        public async Task<Movie>? Update(Guid Id, MovieDTO movie)
        {
            var m = await UnitOfWork.movieRepository.FindByIdAsync(Id);
            if (m == null)
            {
                return null;
            }

            m.MovieLength = movie.MovieLength;
            m.MovieName = movie.MovieName;
            m.StudioName = movie.StudioName;

            await UnitOfWork.movieRepository.SaveAsync();
            return m;
        }

        public List<Movie> GetByStudio(string Studio)
        {
            return UnitOfWork.movieRepository.GetMoviesByStudio(Studio);
        }
    }
}
