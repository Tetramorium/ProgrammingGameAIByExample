using System;
using System.Collections.Generic;
using System.Text;

namespace StateMachineLibrary
{
    public interface IState<T>
    {
        void Enter(T _Entity);
        void Excecute(T _Entity);
        void Exit(T _Entity);
    }
}
