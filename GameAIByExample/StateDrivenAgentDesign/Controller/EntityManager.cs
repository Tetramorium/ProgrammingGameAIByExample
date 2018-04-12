using StateDrivenAgentDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Controller
{
    public class EntityManager
    {
        private Dictionary<int, BaseGameEntity> Entities;

        private static EntityManager EM;

        public static EntityManager Instance
        {
            get
            {
                if (EM == null)
                {
                    EM = new EntityManager();
                }

                return EM;
            }
        }

        private EntityManager()
        {
            this.Entities = new Dictionary<int, BaseGameEntity>();
        }

        public void RegisterEntity(BaseGameEntity _Entity)
        {
            this.Entities.Add(_Entity.Id, _Entity);
        }

        public void UnregisterEntity(BaseGameEntity _Entity)
        {
            this.Entities.Remove(_Entity.Id);
        }

        public BaseGameEntity GetEntity(int _Id)
        {
            return this.Entities[_Id];
        }
    }
}
