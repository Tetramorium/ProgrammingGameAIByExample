using Microsoft.Xna.Framework;
using StateDrivenUIDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenUIDesign.View.ViewStates
{
    public class GameState : IState<GameView>
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


        public void Enter(GameView _Entity)
        {
        }

        public void Excecute(GameView _Entity)
        {
            _Entity.GraphicsDevice.Clear(Color.Red);
        }

        public void Exit(GameView _Entity)
        {
        }
    }
}
