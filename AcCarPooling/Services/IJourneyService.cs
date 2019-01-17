using System.Collections.Generic;
using AcCarPooling.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace AcCarPooling.Services
{
    public interface IJourneyService
    {
        Journey GetJourney(int id);
        IIncludableQueryable<Journey, ICollection<User>> GetAllJourneys();
        void AddJourney(Journey journey);
        void UpdateJourney(Journey journey);
    }
}