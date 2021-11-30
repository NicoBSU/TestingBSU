using System;
using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane, IEquatable<MilitaryPlane>
    {
        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            this.Type = type;
        }
        
        public MilitaryType Type { get; }

        public bool Equals(MilitaryPlane other) => base.Equals(other) && this.Type == other!.Type;

        public override bool Equals(object obj) => obj is MilitaryPlane plane && this.Equals(plane);

        public override int GetHashCode() => (this.Type, base.GetHashCode()).GetHashCode();

        public override string ToString() => base.ToString() + $", type: {this.Type}";
    }
}
