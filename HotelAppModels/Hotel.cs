using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAppModels
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int RoomsAvailable { get; set; }
        

        public Hotel(int id, string name, string location, int roomsAvailable)
        {
            Id = id;
            Name = name;
            Location = location;
            RoomsAvailable = roomsAvailable;
        }
        public void OccupiedRoom()
        {
            RoomsAvailable--;
            Console.WriteLine($"Available {RoomsAvailable}");
        }


    }
}

