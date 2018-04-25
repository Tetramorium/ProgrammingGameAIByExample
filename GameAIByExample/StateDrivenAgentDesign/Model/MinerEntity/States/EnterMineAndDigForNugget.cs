using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model.MinerEntity.States
{
    public class EnterMineAndDigForNugget : IState<Miner>
    {
        private static EnterMineAndDigForNugget EMADFN;

        private EnterMineAndDigForNugget() { }

        public static EnterMineAndDigForNugget Instance
        {
            get
            {
                if (EMADFN == null)
                {
                    EMADFN = new EnterMineAndDigForNugget();
                }

                return EMADFN;
            }
        }


        public void Enter(Miner _Miner)
        {
            if (_Miner.Location != Location.Mine)
            {
                _Miner.AnnounceTask("Walkin' to the gold mine.");
                _Miner.Location = Location.Mine;
            }
        }

        public void Excecute(Miner _Miner)
        {
            _Miner.AnnounceTask("Pickin' up a nugget.");
            _Miner.GoldCarried++;
            _Miner.Fatigue++;
            _Miner.Thirst += 1;

            if (_Miner.PocketsFull())
            {
                _Miner.StateMachine.ChangeState(VisitBankAndDepositGold.Instance);
            }

            if (_Miner.IsThirsty())
            {
                _Miner.StateMachine.ChangeState(QuenchThirst.Instance);
            }
        }

        public void Exit(Miner _Miner)
        {
            _Miner.AnnounceTask("Ah'm leavin' the gold mine with mah pockets full o' sweet gold");
        }

        public bool OnMessage(Miner _Entity, Telegram _Telegram)
        {
            throw new NotImplementedException();
        }
    }
}
