using StateDrivenAgentDesign.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model.WifeEntity.States
{
    public class CookStew : IState<Wife>
    {
        private static CookStew CS;

        private CookStew() { }

        public static CookStew Instance
        {
            get
            {
                if (CS == null)
                {
                    CS = new CookStew();
                }

                return CS;
            }
        }

        public void Enter(Wife _Entity)
        {
            if(!_Entity.IsCooking)
            {
                _Entity.AnnounceTask("Puttin' the stew in the oven.");

                MessageDispatcher.Instance.DispatchMessage(1.5, _Entity.Id, _Entity.Id, TelegramType.Msg_StewReady);

                _Entity.IsCooking = true;
            }
        }

        public void Excecute(Wife _Entity)
        {
        }

        public void Exit(Wife _Entity)
        {
        }

        public bool OnMessage(Wife _Entity, Telegram _Telegram)
        {
            switch(_Telegram.MsgType)
            {
                case TelegramType.Msg_StewReady:
                    Console.WriteLine(string.Format("Message received by {0} at time {1}", _Entity.ToString(), DateTime.Now.Ticks));
                    _Entity.AnnounceTask("Stew ready! Let's eat");

                    MessageDispatcher.Instance.DispatchMessage(0.00, _Entity.Id, 1, TelegramType.Msg_StewReady);

                    _Entity.IsCooking = false;

                    return true;
            }

            return false;
        }
    }
}
