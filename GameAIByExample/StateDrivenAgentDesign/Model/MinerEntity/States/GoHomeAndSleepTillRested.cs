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
    }
}
