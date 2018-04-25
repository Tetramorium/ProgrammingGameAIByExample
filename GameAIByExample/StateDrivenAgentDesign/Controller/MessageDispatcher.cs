using StateDrivenAgentDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Controller
{
    public class MessageDispatcher
    {
        List<Telegram> delayedMessages;

        private static MessageDispatcher MD;

        private MessageDispatcher()
        {
            delayedMessages = new List<Telegram>();
        }

        public static MessageDispatcher Instance
        {
            get
            {
                if (MD == null)
                {
                    MD = new MessageDispatcher();
                }

                return MD;
            }
        }

        public void Discharge(BaseGameEntity _Receiver, Telegram _Telegram)
        {
            if (!_Receiver.HandleMessage(_Telegram))
            {
                _Receiver.AnnounceTask("Couldn't handle message!");
            }
        }

        public void DispatchMessage(double _Delay, int _Sender, int _Receiver, TelegramType _Type)
        {

            BaseGameEntity Sender = EntityManager.Instance.GetEntity(_Sender);

            Telegram t = new Telegram(_Delay, _Sender, _Receiver, _Type);

            if (_Delay <= 0.00)
            {
                BaseGameEntity Receiver = EntityManager.Instance.GetEntity(_Receiver);
                Discharge(Receiver, t);
            }
            else
            {
                double currentTime = DateTime.Now.Ticks;
                t.DispatchTime = currentTime + _Delay;
                delayedMessages.Add(t);
            }
        }

        public void DispatchDelayedMessages()
        {
            double currentTime = DateTime.Now.Ticks;
            List<Telegram> toRemove = new List<Telegram>();

            delayedMessages.Sort();

            foreach (Telegram telegram in delayedMessages)
            {
                if (currentTime > telegram.DispatchTime)
                {
                    BaseGameEntity Receiver = EntityManager.Instance.GetEntity(telegram.Receiver);
                    Discharge(Receiver, telegram);
                    toRemove.Add(telegram);
                }
            }

            foreach( Telegram telegram in toRemove )
            {
                delayedMessages.Remove(telegram);
            }
        }
    }
}
