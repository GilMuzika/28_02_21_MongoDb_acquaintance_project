using _28_02_21_MongoDb_acquaintance_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_02_21_MongoDb_acquaintance_project
{

    enum IsDeparture
    {
        Departure,
        Destination,
        Neither
    }

    class ComboRoute
    {
        public IsDeparture IsDeparture;

        public RouteModel Route { get; set; }
        public string DepartureAddress { get => Route.DepartureAddress; }
        public string DestinationAddress { get => Route.DestinationAddress; }

        public ComboRoute(RouteModel route)
        {
            IsDeparture = IsDeparture.Neither;
            Route = route;
        }
        public ComboRoute(RouteModel route, IsDeparture isDep)
        {
            IsDeparture = isDep;
            Route = route;
        }

        public override string ToString()
        {
            switch(IsDeparture)
            {
                case IsDeparture.Departure:
                    return Route.DepartureAddress;
                case IsDeparture.Destination:
                    return Route.DestinationAddress;
                case IsDeparture.Neither:
                    return $"{Route.DestinationAddress} - {Route.DepartureAddress}";
            }
            return $"{Route.DestinationAddress} - {Route.DepartureAddress}";
        }
    }
}
