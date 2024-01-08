using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.IServices;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie GetMovie(int showId)
        {
            try
            {
                var movie = _dbContext.Shows
                .Where(show => show.ShowId == showId)
                .Select(show => show.Movie)
                .FirstOrDefault();

                if (movie == null) 
                {
                    throw new CustomException("Movie Not Found");
                }

                return movie;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
            
        }

        public IEnumerable<Show> GetAllShows(int movieId)
        {
            return _dbContext.Shows
                .Where(show => show.MovieId == movieId)
                .ToList();
        }

        public Show GetShow(int showId)
        {
            try
            {
                Show show = _dbContext.Shows.Find(showId);
                //.Include(s => s.Movie) // Include the associated Movie
                //.FirstOrDefault(s => s.ShowId == showId);

                if (show == null)
                {
                    throw new CustomException("Show Not Found");
                }
                return show;
            }
            catch(Exception ex)
            {
                throw new CustomException(ex.Message);
            }          
        }


        public IEnumerable<MovieDTO> GetMoviesForToday()
        {
            try
            {
                // If no date is specified, default to the current date
                DateTime currentDate = DateTime.Now.Date;

                // Retrieve all movies currently shown on the current date
                var moviesForDate = _dbContext.Movies
                    .Where(m => m.Shows.Any(s => s.StartDate.Date <= currentDate && s.EndDate.Date >= currentDate))
                    .Select(m => new MovieDTO
                    {
                        MovieId = m.MovieId,
                        MovieName = m.MovieName,
                        Genre = m.Genre,
                        Director = m.Director,
                        Description = m.Description,
                        // Include other relevant movie properties
                    })
                    .ToList();
                if (moviesForDate.Count == 0)
                {
                    throw new CustomException("No movies found for today");
                }

                return moviesForDate;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
            
        }

        public IEnumerable<MovieDTO> GetMoviesForDate(DateTime selectedDate)
        {
            try
            {
                // Retrieve all movies currently shown on the selected date
                var moviesForDate = _dbContext.Movies
                    .Where(m => m.Shows.Any(s => s.StartDate.Date <= selectedDate && s.EndDate.Date >= selectedDate))
                    .Select(m => new MovieDTO
                    {
                        MovieId = m.MovieId,
                        MovieName = m.MovieName,
                        Genre = m.Genre,
                        Director = m.Director,
                        Description = m.Description,
                        // Include other relevant movie properties
                    })
                    .ToList();
                if (moviesForDate.Count == 0)
                {
                    throw new CustomException("No movies found for selected date");
                }

                return moviesForDate;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }

        }




        public void DeleteMovie(int movieId)
        {
            try
            {
                var movieToDelete = _dbContext.Movies.Find(movieId);
                //var showToDelete = _dbContext.Shows.Find(s => s.MovieId == movieId);
                var showToDelete = _dbContext.Shows.FirstOrDefault(movie => movie.MovieId == movieId);
                if (movieToDelete == null || showToDelete == null)
                {
                    throw new CustomException("Movie Not Found");
                }
                _dbContext.Movies.Remove(movieToDelete);
                _dbContext.Shows.Remove(showToDelete);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }


        }

        public void AddMovie(MovieDetailsDTO movieDetailsDTO)
        {
            try
            {
                if (MovieExists(movieDetailsDTO.ScreenNumber, movieDetailsDTO.Timings, movieDetailsDTO.StartDate, movieDetailsDTO.EndDate))
                {
                    throw new InvalidOperationException("A movie is already scheduled at the same screen, timing, and date.");
                }


                // Convert MovieDTO to Movie entity and save it to the database
                var movie = new Movie
                {
                    MovieName = movieDetailsDTO.MovieName,
                    Genre = movieDetailsDTO.Genre,
                    Director = movieDetailsDTO.Director,
                    Description = movieDetailsDTO.Description
                    // Set other movie properties as needed
                };

                var show = new Show
                {
                    StartDate = movieDetailsDTO.StartDate,
                    EndDate = movieDetailsDTO.EndDate,
                    Timings = movieDetailsDTO.Timings,
                    NoOfSeats = movieDetailsDTO.NoOfSeatsAvailable,
                    Price = movieDetailsDTO.PerPersonPrice,
                    MovieId = movie.MovieId,
                    ScreenNumber = movieDetailsDTO.ScreenNumber,
                };

                movie.Shows.Add(show);
                // Save the movie to the database
                _dbContext.Movies.Add(movie);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
            
        }

        private bool MovieExists(int screenNumber, TimeSpan timings, DateTime startDate, DateTime endDate)
        {
            // Check if a movie exists with the same screen, timings, and overlapping dates
            return _dbContext.Movies
                .Any(m =>
                    m.Shows.Any(s =>
                        s.ScreenNumber == screenNumber &&
                        s.Timings == timings &&
                        ((startDate >= s.StartDate && startDate <= s.EndDate) ||
                         (endDate >= s.StartDate && endDate <= s.EndDate) ||
                         (startDate <= s.StartDate && endDate >= s.EndDate))));
        }
    }
}
