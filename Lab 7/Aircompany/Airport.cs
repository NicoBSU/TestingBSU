using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public readonly List<Plane> Planes;

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetAllPassengersPlanes()
        {
            return Planes.Where(p => p.GetType() == typeof(PassengerPlane)).Select(p => (PassengerPlane)p).ToList();
        }

        public List<MilitaryPlane> GetAllMilitaryPlanes()
        {
            return Planes.Where(p => p.GetType() == typeof(MilitaryPlane)).Select(p => (MilitaryPlane)p).ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            var allPassangerPlanes = GetAllPassengersPlanes();
            var biggestPassangersCapacity = allPassangerPlanes.Select(pp => pp.GetPassengersCapacity()).ToList().Max();
            return allPassangerPlanes.Find(pp => pp.GetPassengersCapacity() == biggestPassangersCapacity);
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetAllMilitaryPlanes().Where(mp => mp.GetPlaneType() == MilitaryType.TRANSPORT).ToList();
        }

        public Airport SortByMaxFlightDistance()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxFlightDistance()));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxSpeed()));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxLoadCapacity()));
        }


        public IEnumerable<Plane> GetAllPlanes()
        {
            return Planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", Planes.Select(x => x.GetModel())) +
                    '}';
        }
    }
}
