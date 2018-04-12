using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model
{
    public abstract class BaseGameEntity
    {
        public int Id { get; set; }
        public  string Name { get; set; }

        public BaseGameEntity(int _Id, string _Name)
        {
            this.Id = _Id;
            this.Name = _Name;
        }

        public abstract void Update();
        public abstract bool HandleMessage(Telegram _Telegram);

        public void AnnounceTask(string str)
        {
            Console.WriteLine(this.ToString() + ": " + str);
        }
    }
}
