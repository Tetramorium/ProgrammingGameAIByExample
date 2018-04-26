using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomouslyMovingGameAgents.Model
{
    public class GameWorld
    {
        private static GameWorld instance;

        public static GameWorld Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameWorld();
                return instance;
            }
        }

        public List<Vehicle> Vehicles { get; set; }

        private GameWorld()
        {
            this.Vehicles = new List<Vehicle>();

            Vehicle v = new Vehicle(new Vector2(250, 250), "1");
            v.Target = new Vector2(300, 400);

            this.Vehicles.Add(v);
        }
    }
}
