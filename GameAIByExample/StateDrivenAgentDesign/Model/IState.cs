using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model
{
    public interface IState <T>
    {
        void Enter(T _Entity);
        void Excecute(T _Entity);
        void Exit(T _Entity);
    }
}
