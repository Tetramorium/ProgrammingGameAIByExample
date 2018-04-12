using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model.WifeEntity.States
{
    public class VisitBathroom : IState<Wife>
    {
        private static VisitBathroom VB;

        private VisitBathroom() { }

        public static VisitBathroom Instance
        {
            get
            {
                if (VB == null)
                {
                    VB = new VisitBathroom();
                }

                return VB;
            }
        }

        public void Enter(Wife _Entity)
        {
            _Entity.AnnounceTask("Walkin' to the loo.");
        }

        public void Excecute(Wife _Entity)
        {
            _Entity.AnnounceTask("Ahhh! Sweet relief!");
            _Entity.StateMachine.ChangeState(DoHouseWork.Instance);
        }

        public void Exit(Wife _Entity)
        {
            _Entity.AnnounceTask("Leavin' the loo.");
        }
    }
}
