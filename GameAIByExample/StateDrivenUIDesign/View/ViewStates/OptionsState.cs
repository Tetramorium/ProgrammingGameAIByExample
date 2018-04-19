using Microsoft.Xna.Framework;
using StateDrivenUIDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenUIDesign.View.ViewStates
{
    class OptionsState : State<GameView>
    {
        private static OptionsState OS;

        private OptionsState() { }

        public static OptionsState Instance
        {
            get
            {
                if (OS == null)
                {
                    OS = new OptionsState();
                }

                return OS;
            }
        }


        public override void Enter(GameView _Entity)
        {
        }

        public override void Excecute(GameView _Entity)
        {
            _Entity.GraphicsDevice.Clear(Color.Beige);

            _Entity.spriteBatch.Begin();

            DrawString(_Entity, 0, 100, "Options:", true, Color.Black);

            _Entity.spriteBatch.End();
        }

        public override void Exit(GameView _Entity)
        {
        }
    }
}
