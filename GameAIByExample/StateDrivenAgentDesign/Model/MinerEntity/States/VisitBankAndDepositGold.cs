using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model.MinerEntity.States
{
    public class VisitBankAndDepositGold : IState<Miner>
    {
        private static VisitBankAndDepositGold VBADG;

        private VisitBankAndDepositGold() { }

        public static VisitBankAndDepositGold Instance
        {
            get
            {
                if (VBADG == null)
                {
                    VBADG = new VisitBankAndDepositGold();
                }

                return VBADG;
            }
        }


        public void Enter(Miner _Miner)
        {
            if (_Miner.Location != Location.Bank)
            {
                _Miner.Location = Location.Bank;
                _Miner.AnnounceTask("Goin' to the bank.");
            }
        }

        public void Excecute(Miner _Miner)
        {
            _Miner.MoneyInBank += _Miner.GoldCarried;
            _Miner.GoldCarried = 0;

            _Miner.AnnounceTask("Depositin' gold. Total savings now: " + _Miner.MoneyInBank);

            if (_Miner.MoneyInBank >= 5)
            {
                _Miner.AnnounceTask("Woohoo! I am rich enough for now. Time to go home.");
                _Miner.StateMachine.ChangeState(GoHomeAndSleepTillRested.Instance);
            }
            else
            {
                _Miner.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public void Exit(Miner _Miner)
        {
            _Miner.AnnounceTask("Leavin' the bank.");
        }

        public bool OnMessage(Miner _Entity, Telegram _Telegram)
        {
            throw new NotImplementedException();
        }
    }
}
