using System.Collections.Generic;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;

namespace Aircompany.Tests
{
    public sealed class TestsData
    {
        public static IEnumerable<TestCaseData> TestCasesForGetMaxPassengersCapacity
        {
            get
            {
                yield return new TestCaseData(new List<Plane>()
                {
                    new PassengerPlane("Boeing-737", 900, 12000, 60500, 164),
                    new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 192),
                    new PassengerPlane("Boeing-747", 980, 16100, 70500, 242),
                    new PassengerPlane("Airbus A320", 930, 11800, 65500, 188),
                    new PassengerPlane("Airbus A330", 990, 14800, 80500, 222),
                    new PassengerPlane("Embraer 190", 870, 8100, 30800, 64),
                    new PassengerPlane("Sukhoi Superjet 100", 870, 11500, 50500, 140),
                    new PassengerPlane("Bombardier CS300", 920, 11000, 60700, 196),
                    new MilitaryPlane("B-1B Lancer", 1050, 21000, 80000, MilitaryType.BOMBER),
                    new MilitaryPlane("B-2 Spirit", 1030, 22000, 70000, MilitaryType.BOMBER),
                    new MilitaryPlane("B-52 Stratofortress", 1000, 20000, 80000, MilitaryType.BOMBER),
                    new MilitaryPlane("F-15", 1500, 12000, 10000, MilitaryType.FIGHTER),
                    new MilitaryPlane("F-22", 1550, 13000, 11000, MilitaryType.FIGHTER),
                    new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)
                }).Returns(new PassengerPlane("Boeing-747", 980, 16100, 70500, 242));
                
                yield return new TestCaseData(new List<Plane>(){
                        new PassengerPlane("Boeing-737", 900, 12000, 60500, 222),
                        new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 222),
                        new PassengerPlane("Boeing-747", 980, 16100, 70500, 222),
                        new PassengerPlane("Airbus A320", 930, 11800, 65500, 222),
                        new PassengerPlane("Airbus A330", 990, 14800, 80500, 222),
                        new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)})
                    .Returns(new PassengerPlane("Boeing-737", 900, 12000, 60500, 222));

                yield return new TestCaseData(new List<Plane>()
                {
                    new MilitaryPlane("B-1B Lancer", 1050, 21000, 80000, MilitaryType.BOMBER),
                    new MilitaryPlane("B-2 Spirit", 1030, 22000, 70000, MilitaryType.BOMBER),
                    new MilitaryPlane("B-52 Stratofortress", 1000, 20000, 80000, MilitaryType.BOMBER),
                    new MilitaryPlane("F-15", 1500, 12000, 10000, MilitaryType.FIGHTER),
                    new MilitaryPlane("F-22", 1550, 13000, 11000, MilitaryType.FIGHTER),
                    new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)
                }).Returns(null);
            }
        }
        
        public static IEnumerable<TestCaseData> TestCasesForGetTransportMilitaryPlanes
        {
            get
            {
                yield return new TestCaseData(new List<Plane>(){
                        new PassengerPlane("Boeing-737", 900, 12000, 60500, 164),
                        new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 192),
                        new PassengerPlane("Boeing-747", 980, 16100, 70500, 242),
                        new PassengerPlane("Airbus A320", 930, 11800, 65500, 188),
                        new PassengerPlane("Airbus A330", 990, 14800, 80500, 222),
                        new PassengerPlane("Embraer 190", 870, 8100, 30800, 64),
                        new PassengerPlane("Sukhoi Superjet 100", 870, 11500, 50500, 140),
                        new PassengerPlane("Bombardier CS300", 920, 11000, 60700, 196),
                        new MilitaryPlane("B-1B Lancer", 1050, 21000, 80000, MilitaryType.TRANSPORT),
                        new MilitaryPlane("B-2 Spirit", 1030, 22000, 70000, MilitaryType.BOMBER),
                        new MilitaryPlane("B-52 Stratofortress", 1000, 20000, 80000, MilitaryType.BOMBER),
                        new MilitaryPlane("F-15", 1500, 12000, 10000, MilitaryType.FIGHTER),
                        new MilitaryPlane("F-22", 1550, 13000, 11000, MilitaryType.FIGHTER),
                        new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)})
                    .Returns(new List<MilitaryPlane>()
                    {
                        new MilitaryPlane("B-1B Lancer", 1050, 21000, 80000, MilitaryType.TRANSPORT),
                        new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT),
                    });

                yield return new TestCaseData(new List<Plane>(){
                    new PassengerPlane("Boeing-737", 900, 12000, 60500, 164),
                    new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 192),
                    new PassengerPlane("Boeing-747", 980, 16100, 70500, 242),
                    new PassengerPlane("Airbus A320", 930, 11800, 65500, 188),
                    new PassengerPlane("Airbus A330", 990, 14800, 80500, 222),
                    new PassengerPlane("Embraer 190", 870, 8100, 30800, 64),
                    new PassengerPlane("Sukhoi Superjet 100", 870, 11500, 50500, 140),
                    new PassengerPlane("Bombardier CS300", 920, 11000, 60700, 196),
                    new MilitaryPlane("B-1B Lancer", 1050, 21000, 80000, MilitaryType.BOMBER),
                    new MilitaryPlane("B-2 Spirit", 1030, 22000, 70000, MilitaryType.BOMBER),
                    new MilitaryPlane("B-52 Stratofortress", 1000, 20000, 80000, MilitaryType.BOMBER),
                    new MilitaryPlane("F-15", 1500, 12000, 10000, MilitaryType.FIGHTER),
                    new MilitaryPlane("F-22", 1550, 13000, 11000, MilitaryType.FIGHTER),
                    new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)})
                    .Returns(new List<MilitaryPlane>() {new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)});
                
                yield return new TestCaseData(new List<Plane>(){
                        new PassengerPlane("Boeing-737", 900, 12000, 60500, 222),
                        new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 222),
                        new PassengerPlane("Boeing-747", 980, 16100, 70500, 222),
                        new PassengerPlane("Airbus A320", 930, 11800, 65500, 222),
                        new PassengerPlane("Airbus A330", 990, 14800, 80500, 222)})
                    .Returns(new List<MilitaryPlane>());
            }
        }
        
        public static IEnumerable<TestCaseData> TestCasesForMaxLoadCapacity
        {
            get
            {
                yield return new TestCaseData(new List<Plane>()
                {
                    new PassengerPlane("Boeing-737", 900, 12000, 60500, 164),
                    new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 192),
                    new PassengerPlane("Boeing-747", 980, 16100, 70500, 242),
                    new PassengerPlane("Airbus A320", 930, 11800, 65500, 188),
                    new PassengerPlane("Airbus A330", 990, 14800, 80500, 222),
                    new PassengerPlane("Embraer 190", 870, 8100, 30800, 64),
                    new PassengerPlane("Sukhoi Superjet 100", 870, 11500, 50500, 140),
                    new PassengerPlane("Bombardier CS300", 920, 11000, 60700, 196),
                    new MilitaryPlane("B-1B Lancer", 1050, 21000, 80000, MilitaryType.TRANSPORT),
                    new MilitaryPlane("B-2 Spirit", 1030, 22000, 70000, MilitaryType.BOMBER),
                    new MilitaryPlane("B-52 Stratofortress", 1000, 20000, 80000, MilitaryType.BOMBER),
                    new MilitaryPlane("F-15", 1500, 12000, 10000, MilitaryType.FIGHTER),
                    new MilitaryPlane("F-22", 1550, 13000, 11000, MilitaryType.FIGHTER),
                    new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)
                });

                yield return new TestCaseData(new List<Plane>()
                {
                    new PassengerPlane("Boeing-737", 900, 12000, 60500, 164),
                });

                yield return new TestCaseData(new List<Plane>()
                {
                    new PassengerPlane("Boeing-737", 900, 12000, 60500, 222),
                    new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 222),
                    new PassengerPlane("Boeing-747", 980, 16100, 70500, 222),
                    new PassengerPlane("Airbus A320", 930, 11800, 65500, 222),
                    new PassengerPlane("Airbus A330", 990, 14800, 80500, 222)
                });
            }
        }
    }
}