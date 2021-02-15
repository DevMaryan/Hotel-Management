using HotelAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelAppRepositories;

namespace HotelAppServices
{
    public class HotelAppService
    {

        public HotelAppService()
        {
            //Hotels = new List<Hotel>();
            //Administrations = new List<Administration>(); // Create List otherwise nullObjectreference.
            //Guests = new List<Guest>();
            _hotelRepository = new HotelRepository();
            _guestRepository = new GuestRepository();
            _AdministrationRepository = new AdministrationRepository();

        }

        //public List<Hotel> Hotels { get; set; }
        //public List<Administration> Administrations { get; set; }
        //public List<Guest> Guests { get; set; }
        public HotelRepository _hotelRepository { get; set; }
        public GuestRepository _guestRepository { get; set; }
        public AdministrationRepository _AdministrationRepository { get; set; }



        /// <summary>
        /// Hotel Service
        /// </summary>
        public void CreateHotel()
        {
            Console.WriteLine("Enter hotel name");
            var HotelName = Console.ReadLine();
            Console.WriteLine("Enter hotel location");
            var HotelLocation = Console.ReadLine();
            Console.WriteLine("Enter number of rooms");
            var HotelRoomsNumber = int.Parse(Console.ReadLine());

            Hotel newHotel = new Hotel(GenerateId(), HotelName, HotelLocation, HotelRoomsNumber) ;

            if(newHotel != null)
            {
                try
                {
                    _hotelRepository.Create(newHotel);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{ e.Message }, CreateHotel Error");
                }
            }     
        }



        // View all Hotels
        public void ViewAllHotels()
        {
            ShowAll();
        }

        private void ShowAll()
        {
            foreach (var hotel in _hotelRepository.DataHotels)
            {
                Console.WriteLine($"ID {hotel.Id} - Hotel  {hotel.Name} - Located {hotel.Location} ");
                
            }
        }
        // Delete a Hotel
        
        public void DeleteHotel()
        {
            // Show all hotels
            ShowAll();
            // Choose hotel
            Console.WriteLine("Please choose an ID");
            var userSelect = int.Parse(Console.ReadLine());
            // Select ID firstOrDefault
            var selectedHotel = _hotelRepository.DataHotels.FirstOrDefault(x => x.Id == userSelect);
            _hotelRepository.Delete(selectedHotel);
            Console.WriteLine($"{selectedHotel} has been deleted.");
            ShowAll();
        }

        // Edit a Hotel 
            
        public void EditHotel()
        {
            // Show All Hotels
            ShowAll();

            // Select Hotel
            Console.WriteLine("Please choose the Hotel that you want to edit");
            var hotelSelected = int.Parse(Console.ReadLine());
            var selectHotel = _hotelRepository.DataHotels.FirstOrDefault(x => x.Id == hotelSelected);
            // User can Edit only Rooms and Location
            Console.WriteLine("What would you like to edit?");
            Console.WriteLine("1 - Name");
            Console.WriteLine("2 - Location");
            Console.WriteLine("3 - Rooms Number");
            var userChoice = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("You chose to change the name.");
                    Console.WriteLine("Please enter the new name of the hotel");
                    var newName = Console.ReadLine();
                    selectHotel.Name = newName;
                    break;
                case 2:
                    Console.WriteLine("You chose to change the Location.");
                    Console.WriteLine("Please enter the new address for the hotel");
                    var newLocation = Console.ReadLine();
                    selectHotel.Location = newLocation;
                    break;
                case 3:
                    Console.WriteLine("You chose to change the number of the rooms.");
                    Console.WriteLine("Please enter the new number");
                    var newRoomsNumber = int.Parse(Console.ReadLine());
                    selectHotel.RoomsAvailable = newRoomsNumber;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

        // Generate Id for Hotels
        public int GenerateId()
        {
            var newId = 0;
            if (_hotelRepository.DataHotels.Count > 0)
            {
                newId = _hotelRepository.DataHotels.Max(x => x.Id);
            }
            return newId + 1;
        }

        /// <summary>
        /// Administration Service
        /// </summary>


        // Create Employee
        public void CreateEmployee()
        {
            // id, name, surname, role, salary

            // Request information
            Console.WriteLine("Please fulfill the data for the new employee!");
            Console.WriteLine("Employee Name ");
            var EmpName = Console.ReadLine();
            Console.WriteLine("Employee Surname");
            var EmpSurname = Console.ReadLine();
            List<string> roles = new List<string>() { "1. Frontdesk", "2. Manager", "3. Valet", "4. Service" };
            foreach(var role in roles)
            {
                Console.WriteLine(role);
            }
            Console.WriteLine("Employee Role");
            var EmpRole = int.Parse(Console.ReadLine());

            Console.WriteLine("Employee Salary");
            var EmpSalary = int.Parse(Console.ReadLine());

            EmployeeRole(EmpName, EmpSurname, EmpRole, EmpSalary);

        }

        // View Employee

        public void ViewAllEmployees()
        {
            ShowAllEmployees();
        }

        public void GetSalary()
        {
            foreach (var admin in _AdministrationRepository.DataAdministration)
            {
                Console.WriteLine($"ID {admin.Id} - Name  {admin.Name} - Surname {admin.Surname} - Role {admin.Role} - Salary ${admin.Salary} - Hired at {admin.Date}");
            }
        }

        // Delete Employee

        public void DeleteEmployee()
        {
            // We have to list the all Employees first
            ShowAllEmployees();

            // Choose hotel
            Console.WriteLine("Please choose an ID");
            var selectEmployee = int.Parse(Console.ReadLine());

            // Select ID firstOrDefault
            var selectedEmployee = _AdministrationRepository.DataAdministration.FirstOrDefault(x => x.Id == selectEmployee);
            // Delete the employee
            _AdministrationRepository.Delete(selectedEmployee);

            // Send Message that the employee is deleted!
            Console.WriteLine($"Employee {selectedEmployee.Name} is deleted.");
            Console.WriteLine();

            // Show Update of Employee List
            ShowAllEmployees();
            Console.WriteLine();
        }
        string pwd = "root";
        public void ViewSalary()
        {
            
            var userGuest = 3;

            while(userGuest != 0)
            {
                var userGuess = Console.ReadLine();
                if(userGuess != pwd)
                {
                    userGuest--;
                    Console.WriteLine("The password is incorrect, please try again!");
                    Console.WriteLine($"{userGuest} remains.");
                }else if(userGuess == pwd)
                {
                    Console.WriteLine("!!!Access Granded!!!");
                    GetSalary();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

            }


        }
        public void ChangePwd()
        {
            Console.WriteLine("Please enter the old password");
            var userEnterPwd = Console.ReadLine();
            if (userEnterPwd != "root")
            {
                Console.WriteLine("The password is incorrect");
            }
            else
            {
                Console.WriteLine("Please enter the new password");
                var newPwd = Console.ReadLine();
                pwd = newPwd;
            }

        }

        // Edit Employee
        public void EditEmployee()
        {
            // Show All Employees
            ShowAllEmployees();
            // Choose an employee
            Console.WriteLine("Please choose employee ID ");
            var chooseEmp = int.Parse(Console.ReadLine());
            // Match the EMP ID with List ID 
            var selectEmp = _AdministrationRepository.DataAdministration.FirstOrDefault(x => x.Id == chooseEmp);

            // What would you like to update?
            Console.WriteLine("What would you like to update?");
            Console.WriteLine();
            Console.WriteLine("1. Employee Salary");
            Console.WriteLine("2. Employee Role");
            var updateChoice = int.Parse(Console.ReadLine());

            // Update employee data
            if (updateChoice == 1)
            {
                Console.WriteLine("Enter new salary");
                var newSalary = int.Parse(Console.ReadLine());
                selectEmp.Salary = newSalary;
                Console.WriteLine($"{selectEmp.Name}'s new salary is {newSalary}");
            }else if(updateChoice == 2)
            {
                List<string> roles = new List<string>() { "1. Frontdesk", "2. Manager", "3. Valet", "4. Service" };
                foreach (var role in roles)
                {
                    Console.WriteLine(role);
                }

                Console.WriteLine("Enter new Role");
                var newRole = int.Parse(Console.ReadLine());

                if(newRole == 1)
                {
                    selectEmp.Role = "Frontdesk";
                    Console.WriteLine($"{selectEmp.Name}'s new role is {newRole} ");
                }else if(newRole == 2)
                {
                    selectEmp.Role = "Manager";
                    Console.WriteLine($"{selectEmp.Name}'s new role is {newRole} ");
                }else if(newRole == 3)
                {
                    selectEmp.Role = "Valet";
                    Console.WriteLine($"{selectEmp.Name}'s new role is {newRole} ");
                }else if(newRole == 4)
                {
                    selectEmp.Role = "Service";
                    Console.WriteLine($"{selectEmp.Name}'s new role is {newRole} ");
                }

            }
            else
            {
                Console.WriteLine("Invalid Input");
            }


        }

        // Generate Id for Employees
        public int GenerateIdEmp()
        {
            var newId = 0;
            if (_AdministrationRepository.DataAdministration.Count > 0)
            {
                newId = _AdministrationRepository.DataAdministration.Max(x => x.Id);
            }
            return newId + 1;
        }

        private void ShowAllEmployees()
        {
            foreach (var admin in _AdministrationRepository.DataAdministration)
            {
                Console.WriteLine($"ID {admin.Id} - Name  {admin.Name} - Surname {admin.Surname} - Role {admin.Role} - Hired {admin.Date}");
            }
        }
        public void EmployeeRole(string EmpName, string EmpSurname, int EmpRole, int EmpSalary)
        {
            DateTime localDate = DateTime.Now;

            if (EmpRole == 1)
            {
                var fd = "Frontdesk";
                Administration newEmployee = new Administration(GenerateIdEmp(), EmpName, EmpSurname, fd, EmpSalary, localDate);

                if (_AdministrationRepository.DataAdministration != null)
                {
                    try
                    {
                        _AdministrationRepository.Create(newEmployee);
                        Console.WriteLine("New Employee successfully created!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{ e.Message }, Couldn't create employee");
                    }
                }
            }
            else if (EmpRole == 2)
            {
                var fd = "Manager";
                Administration newEmployee = new Administration(GenerateIdEmp(), EmpName, EmpSurname, fd, EmpSalary, localDate);

                if (_AdministrationRepository.DataAdministration != null)
                {
                    try
                    {
                        _AdministrationRepository.Create(newEmployee);
                        Console.WriteLine("New Employee successfully created!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{ e.Message }, Couldn't create employee");

                    }
                }

            }
            else if (EmpRole == 3)
            {
                var fd = "Valet";
                Administration newEmployee = new Administration(GenerateIdEmp(), EmpName, EmpSurname, fd, EmpSalary, localDate);

                if (_AdministrationRepository.DataAdministration != null)
                {
                    try
                    {
                        _AdministrationRepository.Create(newEmployee);
                        Console.WriteLine("New Employee successfully created!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{ e.Message }, Couldn't create employee");
                    }
                }
            }
            else if (EmpRole == 4)
            {
                var fd = "Service";
                Administration newEmployee = new Administration(GenerateIdEmp(), EmpName, EmpSurname, fd, EmpSalary, localDate);

                if (_AdministrationRepository.DataAdministration != null)
                {
                    try
                    {
                        _AdministrationRepository.Create(newEmployee);
                        Console.WriteLine("New Employee successfully created!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{ e.Message }, Couldn't create employee");
                    }
                }
            }
        }
        /// <summary>
        /// Guest Service
        /// </summary>
                
        // Guest Create
        public void CreateGuest()
        {
            // Get Guest Data
            Console.WriteLine("Enter Guest Name");
            var guestName = Console.ReadLine();

            Console.WriteLine("Enter Guest Surname");
            var guestSurname = Console.ReadLine();

            Console.WriteLine("Enter Guest Phone number");
            var guestPhone = Console.ReadLine();

            Console.WriteLine("How many days is staying?");
            var guestDays = int.Parse(Console.ReadLine());
            DateTime localDate = DateTime.Now;

  
            Guest newGuest = new Guest(GenerateIdGuest(), guestName, guestSurname, guestPhone, guestDays, localDate);
            if(newGuest != null)
            {
                try
                {
                    _guestRepository.DataGuests.Add(newGuest);

                    Console.WriteLine($"The guest {newGuest.Name} checked in!");


                    var tot = guestDays * 120;
                    Console.WriteLine($"Receipt: \n Total Amount: ${tot}");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("NullReferenceException");
                }
                

            }

        }

        // View Guests
        public void ViewGuests()
        {
            GetAllGuests();
        }


        // Delete Guest

        public void DeleteGuest()
        {
            // Show all guests
            GetAllGuests();

            Console.WriteLine("Please choose Guest ID that you want to delete.");
            var userChoice = int.Parse(Console.ReadLine());

            // Select ID firstOrDefault
            var selectedGuest = _guestRepository.DataGuests.FirstOrDefault(x => x.Id == userChoice);
            if (selectedGuest != null)
            {
                _guestRepository.Delete(selectedGuest);
                Console.WriteLine("");
                Console.WriteLine($"The {selectedGuest.Name} has been deleted!");
                Console.WriteLine("");
                GetAllGuests();
            }
            else
            {
                Console.WriteLine("The list is empty");
            }

        }

        // Update Guest

        public void UpdateGuest()
        {
            // Show all guests
            GetAllGuests();

            // Guest is selected
            Console.WriteLine("Please choose Guest ID that you want to update.");
            var selectGuest = int.Parse(Console.ReadLine());

            // Match the EMP ID with List ID 
            var selectedGuest = _guestRepository.DataGuests.FirstOrDefault(x => x.Id == selectGuest);

            // What user should be able to update
            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. Guest extends time");
            Console.WriteLine("2. Guest Phone number");
            var userChoice = int.Parse(Console.ReadLine());

            if(userChoice == 1)
            {
                Console.WriteLine("For how many more days?");
                var userExtends = int.Parse(Console.ReadLine());
                selectedGuest.Days += userExtends;
                Console.WriteLine($"{selectedGuest.Days} days left.");


            }
            else if(userChoice == 2)
            {
                Console.WriteLine($"What is the Guest new phone number?");
                var newPhone = Console.ReadLine();
                selectedGuest.Phone = newPhone;
                Console.WriteLine($"{selectedGuest.Name} new phone number is {newPhone}");
            }
            else
            {
                Console.WriteLine("Invalid Input!");
            }



        }
        public void GetAllGuests()
        {
            if(_guestRepository.DataGuests != null)
            {
                foreach (var guest in _guestRepository.DataGuests)
                {
                    Console.WriteLine($"ID {guest.Id} - Name  {guest.Name} - Surname {guest.Surname} - Phone {guest.Phone} - Staying {guest.Days} days. - Checked in: {guest.Date}");
                }

            }
            else
            {
                Console.WriteLine("The list is empty");
            }

        }

        // Print Receipt

        public void GuestReceipt()
        {
            // Display All Guests
            Console.WriteLine("Please choose a Guest");
            GetAllGuests();
            var userInput = int.Parse(Console.ReadLine());

            // Select Guest
            var selectedGuest = _guestRepository.DataGuests.FirstOrDefault(x => x.Id == userInput);

            selectedGuest.Receipt();

        }
        // Generate Id for Employees
        public int GenerateIdGuest()
        {
            var newId = 0;
            if (_guestRepository.DataGuests.Count > 0)
            {
                newId = _guestRepository.DataGuests.Max(x => x.Id);
            }
            return newId + 1;
        }
        public bool ValidateInteger(int number)
        {
            bool rez = Single.IsNaN(number);
            return rez;
        }
        
    }   

}
