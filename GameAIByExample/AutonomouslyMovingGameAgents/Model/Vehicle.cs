using AutonomouslyMovingGameAgents.SteeringBehaviors;
using AutonomouslyMovingGameAgents.Tools;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomouslyMovingGameAgents.Model
{
    public class Vehicle : MovingEntity
    {
        public Vehicle(Vector2 _Location, string _Name) : base(_Location, _Name)
        {
            this.Mass = 15;
            this.MaxForce = 15;
            this.MaxSpeed = 15;
            this.MaxTurnRate = 100;

            this.BehaviorController.SteeringBehaviors.Add(new ArriveBehaviour(this));
        }

        public override void Update(float _TimeElapsed)
        {
            Vector2 SteeringForce = VectorMath.Truncate(BehaviorController.CombinedSteeringForce(), MaxForce);
            Vector2 Acceleration = SteeringForce / this.Mass;
            this.Velocity += Acceleration * _TimeElapsed;

            this.Velocity = VectorMath.Truncate(this.Velocity, this.MaxSpeed);

            this.Location += this.Velocity * _TimeElapsed;

            if (this.Velocity.LengthSquared() > 0.00000001)
            {
                this.Heading = Vector2.Normalize(this.Velocity);
                this.Side = VectorMath.Perp(this.Heading);
            }

            this.Angle = VectorMath.VectorToAngle(this.Velocity);

            //this.Location = VectorMath.WrapAround(this.Location, 640, 480);
        }
    }
}
