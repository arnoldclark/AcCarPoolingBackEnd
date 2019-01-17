using System.Collections.Generic;
using System.Linq;
using AcCarPooling.Database;
using AcCarPooling.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace AcCarPooling.Services
{
    public class JourneyService : IJourneyService
    {
        private readonly CarPoolContext _carPoolContext;

        public JourneyService(CarPoolContext carPoolContext)
        {
            _carPoolContext = carPoolContext;
        }

        public Journey GetJourney(int id)
        {
            var journey = _carPoolContext.Journeys
                .Include(j => j.Passengers)
                .FirstOrDefault(x => x.Id == id);
            return journey;
        }

        public IIncludableQueryable<Journey, ICollection<User>> GetAllJourneys()
        {
            var journeys = _carPoolContext.Journeys
                .Include(j => j.Passengers);
            return journeys;
        }

        public void AddJourney(Journey journey)
        {
            _carPoolContext.Journeys.Add(journey);
            _carPoolContext.SaveChanges();
        }

        public void UpdateJourney(Journey journey)
        {
            _carPoolContext.Update(journey);
            _carPoolContext.SaveChanges();
        }
    }
}