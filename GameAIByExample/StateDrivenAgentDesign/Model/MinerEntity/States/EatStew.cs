using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model.MinerEntity.States
{
    public class EatStew : IState<Miner>
    {
        private static EatStew ES;

        private EatStew() { }

        public static EatStew Instance
        {
            get
            {
                if (ES == null)
                {
                    ES = new EatStew();
                }

                return ES;
            }
        }

        public void Enter(Miner _Entity)
        {
        }

        public void Excecute(Miner _Entity)
        {
        }

        public void Exit(Miner _Entity)
        {
        }

        public bool OnMessage(Miner _Entity, Telegram _Telegram)
        {
            return false;
        }
    }
}
