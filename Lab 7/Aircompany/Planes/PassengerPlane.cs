using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane, IEquatable<PassengerPlane>
    {
        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            if (passengersCapacity > this.MaxLoadCapacity)
            {
                throw new ArgumentException("Passengers capacity is more than max load capacity.");
            }
            
            this.PassengersCapacity = passengersCapacity;
        }
        
        public int PassengersCapacity { get; }

        public bool Equals(PassengerPlane other) =>
            base.Equals(other) && this.PassengersCapacity == other!.PassengersCapacity;

        public override bool Equals(object obj) => obj is PassengerPlane plane && this.Equals(plane);

        public override int GetHashCode() => (this.PassengersCapacity, base.GetHashCode()).GetHashCode();

        public override string ToString() => base.ToString() + $", passengersCapacity = {this.PassengersCapacity}";
    }
}
