using Microsoft.Xna.Framework;
using StateDrivenUIDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenUIDesign.View.ViewStates
{
    public class GameState : State<GameView>
    {
        private static GameState GS;

        private GameState() { }

        public static GameState Instance
        {
            get
            {
                if (GS == null)
                {
                    GS = new GameState();
                }

                return GS;
            }
        }


        public override void Enter(GameView _Entity)
        {
        }

        public override void Excecute(GameView _Entity)
        {
            _Entity.GraphicsDevice.Clear(Color.Red);

            _Entity.spriteBatch.Begin();

            DrawString(_Entity, 0, 100, "Epic Gameplay", true, Color.Black);

            _Entity.spriteBatch.End();
        }

        public override void Exit(GameView _Entity)
        {
        }
    }
}
