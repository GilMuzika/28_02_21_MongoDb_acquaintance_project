using _28_02_21_MongoDb_acquaintance_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_02_21_MongoDb_acquaintance_project
{
    class ComboCar
    {
        public CarModel Car { get; set; }
        public string Manufacturer { get => Car.Manufacturer; }
        public string License { get => Car.LicenseNumber; }

        public ComboCar(CarModel item)
        {
            Car = item;
        }

        public override string ToString()
        {
            return Manufacturer;
        }
    }
}
