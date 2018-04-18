using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenUIDesign.View.ViewStates
{
    class HighscoreState
    {
        private static HighscoreState HS;

        private HighscoreState() { }

        public static HighscoreState Instance
        {
            get
            {
                if (HS == null)
                {
                    HS = new HighscoreState();
                }

                return HS;
            }
        }


        public void Enter(GameView _Entity)
        {
        }

        public void Excecute(GameView _Entity)
        {
            _Entity.GraphicsDevice.Clear(Color.Beige);
        }

        public void Exit(GameView _Entity)
        {
        }
    }
}