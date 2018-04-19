using Microsoft.Xna.Framework;
using StateDrivenUIDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenUIDesign.View.ViewStates
{
    class HighscoreState : State<GameView>
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


        public override void Enter(GameView _Entity)
        {
        }

        public override void Excecute(GameView _Entity)
        {
            _Entity.GraphicsDevice.Clear(Color.CornflowerBlue);

            _Entity.spriteBatch.Begin();

            DrawString(_Entity, 0, 100, "Highscores:" , true, Color.Black);

            DrawString(_Entity, 0, 160, "ABC: 667", true, Color.Black);

            DrawString(_Entity, 0, 200, "CDA: 324", true, Color.Black);

            DrawString(_Entity, 0, 240, "EFG: 167", true, Color.Black);

            DrawString(_Entity, 0, 280, "HIJ: 005 ", true, Color.Black);

            _Entity.spriteBatch.End();
        }

        public override void Exit(GameView _Entity)
        {
        }
    }
}