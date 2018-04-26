using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutonomouslyMovingGameAgents.Model;
using Microsoft.Xna.Framework;

namespace AutonomouslyMovingGameAgents.SteeringBehaviors
{
    public class SeekBehaviour : SteeringBehaviour
    {
        public SeekBehaviour(MovingEntity me) : base(me)
        {
        }

        public override Vector2 Calculate()
        {
            if (!ME.ArrivedAtTarget && ME.Target != null)
            {
                Vector2 v = ME.Target - ME.Location;
                v.Normalize();
                Vector2 DesiredVelocity = v * ME.MaxSpeed;

                return (DesiredVelocity - ME.Velocity);
            } else
            {
                return Vector2.Zero;
            }
        }
    }
}
