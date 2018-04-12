using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model
{
    public enum TelegramType
    {
        Msg_IAmHome,
        Msg_StewReady
    }

    public class Telegram : IComparable<Telegram>
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }

        public TelegramType MsgType { get; set; }

        public Double DispatchTime { get; set; }

        public Telegram(double _Delay, int _Sender, int _Receiver, TelegramType _Type)
        {
            this.Sender = _Sender;
            this.Receiver = _Receiver;
            this.DispatchTime = _Delay;
            this.MsgType = _Type;
        }

        public int CompareTo(Telegram other)
        {
            if (this.DispatchTime > other.DispatchTime)
                return 1;
            else if (this.DispatchTime == other.DispatchTime)
                return 0;
            else
                return -1;
        }
    }
}
