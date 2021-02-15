using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAppModels
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        
        public int Days { get; set; }

        public DateTime Date { get; set; }
        public Guest(int id, string name, string surname, string phone, int days, DateTime date)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Phone = phone;
            Days = days;
            Date = date;
        }
        public void Receipt()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Dear {Name}, you owe:");
            Console.WriteLine();
            Console.WriteLine("$" + 120 * Days);
            Console.WriteLine();
            Console.WriteLine($"Thank you for choosing us!");
            Console.WriteLine("------------------------------");
        }

    }
}
