using HotelAppServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HotelAppRepositories;

namespace HotelApp
{
    public class MenuHelper
    {
        public static HotelAppService HotelAppService { get; private set; }

        public static void MainMenu()
        {
            HotelAppService = new HotelAppService();


            var shouldStop = "";

            while(shouldStop.ToLower() != "yes")
            {
                Console.WriteLine("What would you like to see?");
                Console.WriteLine("1. Hotel Options");
                Console.WriteLine("2. Guest Options");
                Console.WriteLine("3. Administration Options");

                var MainChoice = Console.ReadLine();

                try
                {
                    switch (MainChoice)
                    {
                        case "1":
                            Console.WriteLine("You choose Hotel Options");
                            HotelOptions();
                            break;
                        case "2":
                            Console.WriteLine("You choose Guest Options");
                            GuestOptions();
                            break;
                        case "3":
                            Console.WriteLine("You choose Administration Options");
                            AdministrationOptions();
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                    Console.WriteLine("Would you like to stop? Enter yes to stop");
                    shouldStop = Console.ReadLine();

                }
                catch (Exception e)
                {
                    var date = new DateTime();
                    Console.WriteLine(date.ToString(), e.Message);
                }

            }
        }


        public static void HotelOptions()
        {
            
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add hotel");
            Console.WriteLine("2. View hotels");
            Console.WriteLine("3. Delete hotel");
            Console.WriteLine("4. Update hotel");

            var HotelOption = Console.ReadLine();
            switch (HotelOption)
            {
                case "1":
                    Console.WriteLine("You choose to add hotel");
                    HotelAppService.CreateHotel();
                    break;
                case "2":
                    Console.WriteLine("You choose to view all hotels");
                    HotelAppService.ViewAllHotels();
                    break;
                case "3":
                    Console.WriteLine("You choose to delete hotel");
                    HotelAppService.DeleteHotel();
                    break;
                case "4":
                    Console.WriteLine("You choose to update hotel");
                    HotelAppService.EditHotel();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
          
        public static void GuestOptions()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add Guest");
            Console.WriteLine("2. View Guests");
            Console.WriteLine("3. Delete Guest");
            Console.WriteLine("4. Update Guest");
            Console.WriteLine("5. Print Receipt");

            var GuestOption = Console.ReadLine();
            switch (GuestOption)
            {
                case "1":
                    Console.WriteLine("You choose to add guest");
                    HotelAppService.CreateGuest();
                    break;
                case "2":
                    Console.WriteLine("You choose to view all guests");
                    HotelAppService.ViewGuests();
                    break;
                case "3":
                    Console.WriteLine("You choose to delete a guest");
                    HotelAppService.DeleteGuest();
                    break;
                case "4":
                    Console.WriteLine("You choose to update guest");
                    HotelAppService.UpdateGuest();
                    break;
                case "5":
                    Console.WriteLine("You choose to print receipt");
                    HotelAppService.GuestReceipt();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

        public static void AdministrationOptions()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View Employees");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. View Salary");
            Console.WriteLine("6. Change password");

            var AdminOption = Console.ReadLine();
            switch (AdminOption)
            {
                case "1":
                    Console.WriteLine("You choose to add employee");
                    HotelAppService.CreateEmployee();
                    break;
                case "2":
                    Console.WriteLine("You choose to view all employees");
                    HotelAppService.ViewAllEmployees();
                    break;
                case "3":
                    Console.WriteLine("You choose to delete an employee");
                    HotelAppService.DeleteEmployee();
                    break;
                case "4":
                    Console.WriteLine("You choose to update an employee");
                    HotelAppService.EditEmployee();
                    break;
                case "5":
                    Console.WriteLine("Please enter your admin password");
                    HotelAppService.ViewSalary();
                    break;
                case "6":
                    Console.WriteLine("Change Admin password");
                    HotelAppService.ChangePwd();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }
}
