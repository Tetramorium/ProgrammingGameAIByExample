using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model.WifeEntity.States
{
    public class DoHouseWork : IState<Wife>
    {
        private static DoHouseWork DHW;

        private DoHouseWork() { }

        public static DoHouseWork Instance
        {
            get
            {
                if (DHW == null)
                {
                    DHW = new DoHouseWork();
                }

                return DHW;
            }
        }


        public void Enter(Wife _Entity)
        {
        }

        public void Excecute(Wife _Entity)
        {
            switch(Tools.Tool.rng.Next(0, 2))
            {
                case 0:
                    _Entity.AnnounceTask("Moppin' the floor.");
                    break;
                case 1:
                    _Entity.AnnounceTask("Washin' the dishes.");
                    break;
                case 2:
                    _Entity.AnnounceTask("Makin' the bed.");
                    break;
            }
        }

        public void Exit(Wife _Entity)
        {
        }
    }
}
