using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        private List<Plane> planes;

        public Airport(IEnumerable<Plane> planes)
        {
            if (planes is null)
            {
                throw new ArgumentNullException(nameof(planes));
            }

            this.planes = new List<Plane>(planes);
        }

        public IEnumerable<PassengerPlane> GetPassengersPlanes()
        {
            var passengerPlanes = new List<PassengerPlane>();

            foreach (var plane in this.planes)
            {
                if (plane is PassengerPlane passengerPlane)
                {
                    passengerPlanes.Add(passengerPlane);
                }
            }
            
            return passengerPlanes;
        }

        public IEnumerable<MilitaryPlane> GetMilitaryPlanes()
        {
            var militaryPlanes = new List<MilitaryPlane>();

            foreach (var plane in this.planes)
            {
                if (plane is MilitaryPlane militaryPlane)
                {
                    militaryPlanes.Add(militaryPlane);
                }
            }
            
            return militaryPlanes;
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            IEnumerable<PassengerPlane> passengerPlanes = GetPassengersPlanes();

            var enumerable = passengerPlanes.ToList();
            PassengerPlane plane = !enumerable.Any() ? null
                : enumerable.OrderByDescending(p => p.PassengersCapacity).FirstOrDefault();

            return plane;
        }

        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            List<MilitaryPlane> transportMilitaryPlanes = new List<MilitaryPlane>();
            IEnumerable<MilitaryPlane> militaryPlanes = GetMilitaryPlanes();

            foreach (var plane in militaryPlanes)
            {
                if (plane.Type == MilitaryType.Transport)
                {
                    transportMilitaryPlanes.Add(plane);
                }
            }
            
            return transportMilitaryPlanes;
        }

        public Airport SortByMaxDistance()
        {
            this.planes.Sort((p, n) =>
            {
                return (p, n) switch
                {
                    (null, null) => 0,
                    (null, _) => -1,
                    (_, null) => 1,
                    ({ } previous, { } next) => previous.MaxFlightDistance - next.MaxFlightDistance,
                };
            });

            return this;
        }

        public Airport SortByMaxSpeed()
        {
            this.planes.Sort((p, n) =>
            {
                return (p, n) switch
                {
                    (null, null) => 0,
                    (null, _) => -1,
                    (_, null) => 1,
                    ({ } previous, { } next) => previous.MaxSpeed - next.MaxSpeed,
                };
            });

            return this;
        }

        public Airport SortByMaxLoadCapacity()
        {
            this.planes.Sort((p, n) =>
            {
                return (p, n) switch
                {
                    (null, null) => 0,
                    (null, _) => -1,
                    (_, null) => 1,
                    ({ } previous, { } next) => previous.MaxLoadCapacity - next.MaxLoadCapacity,
                };
            });

            return this;
        }


        public IEnumerable<Plane> GetPlanes() => this.planes;

        public override string ToString()
        {
            return "Airport.\n" + "planes :" + string.Join(", ", planes.Select(x => x.Model));
        }
    }
}
