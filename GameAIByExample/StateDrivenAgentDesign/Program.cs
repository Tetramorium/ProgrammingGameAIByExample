using StateDrivenAgentDesign.Controller;
using StateDrivenAgentDesign.Model.MinerEntity;
using StateDrivenAgentDesign.Model.WifeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Miner m = new Miner(1, "Miner Bob");
            Wife w = new Wife(2, "Lady Leia");

            EntityManager.Instance.RegisterEntity(m);
            EntityManager.Instance.RegisterEntity(w);

            for (int i = 0; i < 10000; i++)
            {
                Thread.Sleep(1000);
                m.Update();
                w.Update();
                MessageDispatcher.Instance.DispatchDelayedMessages();
            }
        }
    }
}
