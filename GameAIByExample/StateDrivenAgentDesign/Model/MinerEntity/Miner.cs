using StateDrivenAgentDesign.Controller;
using StateDrivenAgentDesign.Model.MinerEntity.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenAgentDesign.Model.MinerEntity
{
    public enum Location
    {
        Mine,
        Bank,
        Saloon,
        Home
    }

    public class Miner : BaseGameEntity
    {
        private const int MaxNuggets = 3;
        private const int EnoughGold = 5;
        private const int MaxThirstLevel = 5;
        private const int TirednessThreshold = 5;

        public StateMachine<Miner> StateMachine { get; set; }

        public double GoldCarried { get; set; }
        public double MoneyInBank { get; set; }
        public double Thirst { get; set; }
        public double Fatigue { get; set; }

        public Location Location { get; set; }

        public Miner(int _Id, string _Name) : base(_Id, _Name)
        {
            StateMachine = new StateMachine<Miner>(this);
            StateMachine.CurrentState = GoHomeAndSleepTillRested.Instance;
            this.Location = Location.Home;
            this.MoneyInBank = 4;
        }

        public override void Update()
        {
            this.Thirst++;
            StateMachine.Update();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public bool PocketsFull()
        {
            return this.GoldCarried >= MaxNuggets;
        }

        public bool IsTired()
        {
            return this.Fatigue >= TirednessThreshold;
        }

        public bool IsRich()
        {
            return this.MoneyInBank >= EnoughGold;
        }

        public bool IsThirsty()
        {
            return this.Thirst >= MaxThirstLevel;
        }

        public override bool HandleMessage(Telegram _Telegram)
        {
            return this.StateMachine.HandleMessage(_Telegram);
        }
    }
}
