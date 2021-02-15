using HotelAppModels;
using System;
using System.Collections.Generic;
using System.Text;


namespace HotelAppRepositories
{
    public class AdministrationRepository
    {
        public AdministrationRepository()
        {
            DataAdministration = new List<Administration>();
        }

        public List<Administration> DataAdministration { get; set; }

        public void Create(Administration newEmployee)
        {
            DataAdministration.Add(newEmployee);

        }

        public void Delete(Administration selectedEmployee)
        {
            DataAdministration.Remove(selectedEmployee);
        }

    }

}
