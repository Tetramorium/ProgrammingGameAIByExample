using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model.MinerEntity.States
{
    public class QuenchThirst : IState<Miner>
    {
        private static QuenchThirst QT;

        private QuenchThirst() { }

        public static QuenchThirst Instance
        {
            get
            {
                if (QT == null)
                {
                    QT = new QuenchThirst();
                }

                return QT;
            }
        }


        public void Enter(Miner _Miner)
        {
            if (_Miner.Location!= Location.Saloon)
            {
                _Miner.Location = Location.Saloon;
                _Miner.AnnounceTask("Boy, ah sure is thusty! Walkin' to the saloon.");
            }
        }

        public void Excecute(Miner _Miner)
        {
            if (_Miner.IsRich())
            {
                _Miner.AnnounceTask("Throwing a party! Drinks on me!");
                _Miner.MoneyInBank = 0;
            } else
            {
                _Miner.AnnounceTask("That's mighty fine sippin liquor.");
                _Miner.MoneyInBank -= 2;             
            }

            _Miner.Thirst = 0;
            _Miner.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
        }

        public void Exit(Miner _Miner)
        {
            _Miner.AnnounceTask("Leaving the saloon, feelin' good!");
        }

        public bool OnMessage(Miner _Entity, Telegram _Telegram)
        {
            throw new NotImplementedException();
        }
    }
}
