using AutonomouslyMovingGameAgents.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomouslyMovingGameAgents.SteeringBehaviors
{
    class ArriveBehaviour : SteeringBehaviour
    {
        public ArriveBehaviour(MovingEntity me) : base(me)
        {
        }

        public override Vector2 Calculate()
        {
            if (!ME.ArrivedAtTarget && ME.Target != null)
            {
                Vector2 ToTarget = ME.Target - ME.Location;
                float Distance = ToTarget.Length();

                if (Distance > 0)
                {
                    float speed = Distance / 25;

                    if(speed> ME.MaxSpeed)
                    {
                        speed = ME.MaxSpeed;
                    }

                    Vector2 DesiredVelocity = ToTarget * speed / Distance;

                    return (DesiredVelocity - ME.Velocity);
                } else
                {
                    return Vector2.Zero;
                }
            }
            else
            {
                return Vector2.Zero;
            }
        }
    }
}
