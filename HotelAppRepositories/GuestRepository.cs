using HotelAppModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAppRepositories
{
    public class GuestRepository
    {
        public GuestRepository()
        {
            DataGuests = new List<Guest>();
        }

        public List<Guest> DataGuests { get; set; }

        public void Create(Guest entity)
        {
            DataGuests.Add(entity);
        }

        public void Delete(Guest selectedGuest)
        {
            DataGuests.Remove(selectedGuest);
        }
    }
}
