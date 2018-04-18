using StateDrivenUIDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenUIDesign.Controller
{
    public class StateMachine<T> //where T : BaseGameEntity
    {
        public T Owner { get; set; }

        public IState<T> CurrentState { get; set; }
        public IState<T> PreviousState { get; set; }
        public IState<T> GlobalState { get; set; }

        public StateMachine(T _Owner)
        {
            this.Owner = _Owner;
        }

        public void Update()
        {
            if (GlobalState != null)
                GlobalState.Excecute(this.Owner);

            if (CurrentState != null)
                CurrentState.Excecute(this.Owner);
        }

        public void ChangeState(IState<T> _NewState)
        {
            PreviousState = CurrentState;
            CurrentState.Exit(this.Owner);
            CurrentState = _NewState;
            CurrentState.Enter(this.Owner);
        }

        public void RevertToPreviousState()
        {
            ChangeState(this.PreviousState);
        }
    }
}