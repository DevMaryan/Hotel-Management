using System;
using System.Collections.Generic;
using System.Linq;
using HotelAppModels;
namespace HotelAppRepositories
{
    public class HotelRepository
    {
        public HotelRepository()
        {
            DataHotels = new List<Hotel>();
        }

        public List<Hotel> DataHotels { get; set; }


        public void Create(Hotel newHotel)
        {
            DataHotels.Add(newHotel);
        }

        public void Delete(Hotel selectedHotel)
        {
            DataHotels.Remove(selectedHotel);
        }
    }
}
