using System;

namespace Aircompany.Planes
{
    public abstract class Plane : IEquatable<Plane>
    {
        public Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            this.Verify(model, maxSpeed, maxFlightDistance, maxLoadCapacity);
            
            this.Model = model;
            this.MaxSpeed = maxSpeed;
            this.MaxFlightDistance = maxFlightDistance;
            this.MaxLoadCapacity = maxLoadCapacity;
        }
        
        public string Model { get; }
        
        public int MaxSpeed { get; }
        
        public int MaxFlightDistance { get; }
        
        public int MaxLoadCapacity { get; }
        

        public override string ToString() => $"Plane model: {this.Model}" +
                $", maxSpeed = {this.MaxSpeed}" +
                $", maxFlightDistance = {this.MaxFlightDistance}" +
                $", maxLoadCapacity = {this.MaxLoadCapacity}";

        public bool Equals(Plane other)
            => other is not null && 
               Model == other.Model &&
               MaxSpeed == other.MaxSpeed &&
               MaxFlightDistance == other.MaxFlightDistance &&
               MaxLoadCapacity == other.MaxLoadCapacity;


        public override bool Equals(object obj) => obj is Plane plane && this.Equals(plane);

        public override int GetHashCode() 
            => (this.Model, this.MaxSpeed, this.MaxLoadCapacity, this.MaxFlightDistance).GetHashCode();

        private void Verify(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            if (string.IsNullOrEmpty(model))
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (maxSpeed < 0)
            {
                throw new ArgumentException("Max speed is less than zero.");
            }
            
            if (maxFlightDistance < 0)
            {
                throw new ArgumentException("Max flight distance is less than zero.");
            }
            
            if (maxLoadCapacity < 0)
            {
                throw new ArgumentException("Max load capacity is less than zero.");
            }
        }
    }
}
