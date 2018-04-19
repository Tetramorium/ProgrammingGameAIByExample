using StateDrivenAgentDesign.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model.MinerEntity.States
{
    public class GoHomeAndSleepTillRested : IState<Miner>
    {
        private static GoHomeAndSleepTillRested GHASTR;

        private GoHomeAndSleepTillRested() { }

        public static GoHomeAndSleepTillRested Instance
        {
            get
            {
                if (GHASTR == null)
                {
                    GHASTR = new GoHomeAndSleepTillRested();
                }

                return GHASTR;
            }
        }


        public void Enter(Miner _Miner)
        {
            if (_Miner.Location != Location.Home)
            {
                _Miner.Location = Location.Home;
                _Miner.AnnounceTask("On me way home.");

                MessageDispatcher.Instance.DispatchMessage(0.00, _Miner.Id, 2, TelegramType.Msg_IAmHome);
            }
        }

        public void Excecute(Miner _Miner)
        {
            _Miner.AnnounceTask("ZzzZzz...");
            _Miner.Fatigue--;

            if (_Miner.Fatigue <= 0)
            {
                _Miner.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public void Exit(Miner _Miner)
        {
            _Miner.AnnounceTask("That was a very good nap! Time to dig for more gold.");
        }

        public bool OnMessage(Miner _Entity, Telegram _Telegram)
        {
            switch (_Telegram.MsgType)
            {
                case TelegramType.Msg_StewReady:
                    Console.WriteLine(string.Format("Message received by {0} at time {1}", _Entity.ToString(), DateTime.Now.Ticks));

                    _Entity.AnnounceTask("Okay hun, ahm a-comin!");

                    _Entity.StateMachine.ChangeState(EatStew.Instance);
                    return true;
            }
            return false;
        }
    }
}
