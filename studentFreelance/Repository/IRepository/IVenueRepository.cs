using System;
using studentFreelance.Models;
using studentFreelance.Views;

namespace studentFreelance.Repository.IRepository
{
    public interface IVenueRepository : IRepository<venue>
    {
        void Update(venue obj);
    }
}

