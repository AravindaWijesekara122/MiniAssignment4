using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovie(int ShowId);
        Show GetShow(int ShowId);
        IEnumerable<ShowDTO> GetAllShows(int MovieId);
        void AddMovie(MovieDetailsDTO movieDetailsDTO);
        void DeleteMovie(int MovieId);

        IEnumerable<MovieDTO> GetMoviesForToday();
        IEnumerable<MovieDTO> GetMoviesForDate(DateTime selectedDate);

        //int GetAvailableSeatCount(int ShowId);
    }
}
