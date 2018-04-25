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
            _Entity.AnnounceTask("Smells Reaaal goood Elsa!");
        }

        public void Excecute(Miner _Entity)
        {
            _Entity.AnnounceTask("Tastes real good too!");
            _Entity.StateMachine.RevertToPreviousState();
        }

        public void Exit(Miner _Entity)
        {
            _Entity.AnnounceTask("Thankya li'lle lady. Ah better get back to whatever ah wuz doin'");
        }

        public bool OnMessage(Miner _Entity, Telegram _Telegram)
        {
            return false;
        }
    }
}
