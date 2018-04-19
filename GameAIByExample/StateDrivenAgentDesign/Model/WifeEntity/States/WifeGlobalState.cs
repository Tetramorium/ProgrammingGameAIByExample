using StateDrivenAgentDesign.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model.WifeEntity.States
{
    public class WifeGlobalState : IState<Wife>
    {
        private static WifeGlobalState WGS;

        private WifeGlobalState() { }

        public static WifeGlobalState Instance
        {
            get
            {
                if (WGS == null)
                {
                    WGS = new WifeGlobalState();
                }

                return WGS;
            }
        }

        public void Enter(Wife _Entity)
        {
        }

        public void Excecute(Wife _Entity)
        {
            if (Tools.Tool.rng.Next(0, 9) < 1)
            {
                _Entity.StateMachine.ChangeState(VisitBathroom.Instance);
            }
        }

        public void Exit(Wife _Entity)
        {
        }

        public bool OnMessage(Wife _Entity, Telegram _Telegram)
        {
            switch (_Telegram.MsgType)
            {
                case TelegramType.Msg_IAmHome:  
                    Console.WriteLine(string.Format("Message handled by {0} at time {1}", _Entity.ToString(), DateTime.Now.Ticks));
                    _Entity.AnnounceTask("Hi honey. Let me make you some of mah fine country stew.");
                    _Entity.StateMachine.ChangeState(CookStew.Instance);
                    return true;
            }
            return false;
        }
    }
}
