using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.IServices;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ShowService : IShowService
    {
        private readonly ApplicationDbContext _dbContext;

        public ShowService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ShowDTO> GetCurrentShows()
        {
            try
            {
                // Get the current date and time
                DateTime currentDateTime = DateTime.Now;

                // Retrieve all shows currently running
                var currentShows = _dbContext.Shows
                    .Where(s => s.StartDate <= currentDateTime && s.EndDate >= currentDateTime)
                    .Select(s => new ShowDTO
                    {
                        MovieName = s.Movie.MovieName,
                        StartDate = s.StartDate,
                        EndDate = s.EndDate,
                        Timings = s.Timings,
                        NoOfSeats = s.NoOfSeats,
                        PerPersonPrice = s.Price,
                        ScreenNumber = s.ScreenNumber,
                        // Include other relevant show properties
                    })
                    .ToList();
                if (currentShows == null)
                {
                    throw new CustomException("No Shows Found");
                }

                return currentShows;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error : {ex.Message}");
            }
            
        }
    }
}
