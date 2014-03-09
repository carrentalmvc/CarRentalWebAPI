using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rennish.WebAPI.Models;
using Rennish.WebAPI.Repository;

namespace Homes.WebAPI.Controllers
{
    public class ReservationController : ApiController
    {
        IReservationRepository repo = ReservationRepository.GetRepository();

        public IEnumerable<Reservation> GetAllReservations()
        {
            return repo.GetAll();
        }

        public Reservation GetReservation(int Id)
        {

            return repo.Get(Id);
        }

        [HttpPost]
        public Reservation CreateReservation(Reservation item)
        {
            return repo.Add(item);
        }

        [HttpPut]
        public bool UpdateReservation(Reservation item)
        {
            return repo.Update(item);
        }

        [HttpDelete]
        public void DeleteReservation(int Id)
        {
            repo.Remove(Id);
        }
    }
}
