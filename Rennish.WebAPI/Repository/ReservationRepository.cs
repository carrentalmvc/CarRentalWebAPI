using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rennish.WebAPI.Models;

namespace Rennish.WebAPI.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private static ReservationRepository _instance;

       private List<Reservation> data = new List<Reservation>{
        
           new Reservation{ClientName = "Rennish" ,ReservationId = 1,Location = "Jax,Florida"},
           new Reservation{ClientName = "John" ,ReservationId = 2,Location = "Calicut,India"},
           new Reservation{ClientName = "Bibin" ,ReservationId = 3,Location = "Houston,Texas"}
        };

       public static ReservationRepository GetRepository()
       {
           if (_instance == null)
           {
               _instance = new ReservationRepository();
               return _instance;
           }

           return _instance;
       }

        public IEnumerable<Reservation> GetAll()
        {
            return data;
        }

        public Reservation Get(int Id)
        {
            return data.Where(r => r.ReservationId == Id).SingleOrDefault();            
        }

        public Reservation Add(Reservation item)
        {
            item.ReservationId = data.Count + 1;
            data.Add(item);
            return item;
        }

        public void Remove(int Id)
        {
            if (data.Any())
            {
                data.Remove(data.Where(i => i.ReservationId == Id).SingleOrDefault());
            }
        }

        public bool Update(Reservation item)
        {
            var storedItem = this.Get(item.ReservationId);
            if (storedItem != null)
            {
                storedItem.ClientName = item.ClientName;
                storedItem.Location = item.Location;
                return true;
            }

            return false;
        }
    }
}