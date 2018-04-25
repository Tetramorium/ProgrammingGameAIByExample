using StateDrivenAgentDesign.Controller;
using StateDrivenAgentDesign.Model.WifeEntity.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model.WifeEntity
{
    public class Wife : BaseGameEntity
    {
        public StateMachine<Wife> StateMachine { get; set; }

        public bool IsCooking { get; set; }

        public Wife(int _Id, string _Name) : base(_Id, _Name)
        {
            StateMachine = new StateMachine<Wife>(this);
            StateMachine.CurrentState = DoHouseWork.Instance;
            StateMachine.GlobalState = WifeGlobalState.Instance;
        }

        public override void Update()
        {
            StateMachine.Update();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool HandleMessage(Telegram _Telegram)
        {
            return this.StateMachine.HandleMessage(_Telegram);
        }
    }
}
