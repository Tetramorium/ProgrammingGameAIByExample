using AutonomouslyMovingGameAgents.SteeringBehaviors;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomouslyMovingGameAgents.Controller
{
    public class BehaviourController
    {
        public List<SteeringBehaviour> SteeringBehaviors { get; set; }

        public BehaviourController()
        {
            this.SteeringBehaviors = new List<SteeringBehaviour>();
        }

        public Vector2 CombinedSteeringForce()
        {
            Vector2 v = Vector2.Zero;

            foreach(SteeringBehaviour sb in SteeringBehaviors)
            {
                v += sb.Calculate();
            }

            return v;
        }
    }
}
