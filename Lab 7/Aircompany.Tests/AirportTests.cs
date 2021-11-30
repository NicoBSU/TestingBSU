using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany.Tests
{
    [TestFixture]
    public class AirportTests
    {
        [TestCaseSource(typeof(TestsData), nameof(TestsData.TestCasesForGetTransportMilitaryPlanes))]
        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes_ReturnTransportMilitaryPlanes(IEnumerable<Plane> planes)
        {
            var airport = new Airport(planes);
            return airport.GetTransportMilitaryPlanes().ToList();
        }

        [TestCaseSource(typeof(TestsData), nameof(TestsData.TestCasesForGetMaxPassengersCapacity))]
        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity_ValidValues_ReturnPlane(IEnumerable<Plane> planes)
        {
            var airport = new Airport(planes);
            return airport.GetPassengerPlaneWithMaxPassengersCapacity();
        }

        [TestCaseSource(typeof(TestsData), nameof(TestsData.TestCasesForMaxLoadCapacity))]
        public void SortByMaxLoadCapacity_ReturnLoadCapacity(IEnumerable<Plane> planes)
        {
            var planesList = planes.ToList();
            var airport = new Airport(planesList).SortByMaxLoadCapacity();
            
            CollectionAssert.AreEqual(airport.GetPlanes(), planesList.OrderBy(p => p.MaxLoadCapacity));
        }
    }
}
