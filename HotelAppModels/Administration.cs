using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAppModels
{
    public class Administration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public int Salary { get; set; }
        public int RoomPrice { get; set; }
        public DateTime Date { get; set; }


        public Administration(int id, string name, string surname, string role, int salary, DateTime date)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Role = role;
            Salary = salary;
            RoomPrice = 120;
            Date = date;
        }
        public int Price(int days)
        {
            return days * RoomPrice;
        }

    }
}
