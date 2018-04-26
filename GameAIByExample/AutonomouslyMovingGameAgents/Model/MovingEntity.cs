using AutonomouslyMovingGameAgents.Controller;
using AutonomouslyMovingGameAgents.SteeringBehaviors;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomouslyMovingGameAgents.Model
{
    public abstract class MovingEntity : BaseGameEntity
    {
        public Vector2 Velocity { get; set; }

        // A normalized vector pointing in the direction the entity is heading.
        public Vector2 Heading { get; set; }
        // A vector perpendicular the heading vector.
        public Vector2 Side { get; set; }

        public float Mass { get; set; }
        public float MaxSpeed { get; set; }
        public float MaxForce { get; set; }
        public float MaxTurnRate { get; set; } 

        public bool ArrivedAtTarget { get; set; }
        private Vector2 target;

        public Vector2 Target
        {
            get { return target; }
            set
            {
                this.ArrivedAtTarget = false;
                target = value;
            }
        }


        public BehaviourController BehaviorController { get; set; }

        public MovingEntity(Vector2 _Location, string _Name) : base(_Location, _Name)
        {
            BehaviorController = new BehaviourController();
        }
    }
}
