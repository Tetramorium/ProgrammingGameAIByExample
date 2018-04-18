using Microsoft.Xna.Framework;
using StateDrivenUIDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenUIDesign.View.ViewStates
{
    public class MainMenuState : IState<GameView>
    {
        private static MainMenuState MMS;

        private MainMenuState() { }

        public static MainMenuState Instance
        {
            get
            {
                if (MMS == null)
                {
                    MMS = new MainMenuState();
                }

                return MMS;
            }
        }


        public void Enter(GameView _Entity)
        {
        }

        public void Excecute(GameView _Entity)
        {
            _Entity.GraphicsDevice.Clear(Color.CornflowerBlue);
        }

        public void Exit(GameView _Entity)
        {
        }
    }
}
