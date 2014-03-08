using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rennish.WebAPI.Models;

namespace Rennish.WebAPI.Repository
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();

        Reservation Get(int Id);

        Reservation Add(Reservation item);

        void Remove(int Id);

        bool Update(Reservation item);

    }
}