﻿using AutonomouslyMovingGameAgents.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomouslyMovingGameAgents.SteeringBehaviors
{
    public abstract class SteeringBehaviour
    {
        public MovingEntity ME { get; set; }
        public abstract Vector2 Calculate();

        public SteeringBehaviour(MovingEntity me)
        {
            ME = me;
        }
    }
}
