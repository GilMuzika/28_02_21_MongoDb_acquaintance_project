using _28_02_21_MongoDb_acquaintance_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_02_21_MongoDb_acquaintance_project
{
    class ComboDriver
    {
        public DriverModel Driver { get; set; }

        public ComboDriver(DriverModel driver)
        {
            Driver = driver;
        }

        public override string ToString()
        {
            return $"{Driver.FirstName} {Driver.Lastname}";
        }



    }
}
