using Microsoft.Xna.Framework;
using StateDrivenUIDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenUIDesign.View.ViewStates
{
    public class MainMenuState : State<GameView>
    {
        public enum SelectedOption
        {
            Start,
            Options,
            Highscores,
            Exit
        }

        private SelectedOption[] Options = { SelectedOption.Start, SelectedOption.Options, SelectedOption.Highscores, SelectedOption.Exit };
        private int OptionsCount;

        //public SelectedOption CurrentlySelectedOption { get; set; }
        public int CurrentlySelectedOption;

        private static MainMenuState MMS;

        private MainMenuState() { }

        public static MainMenuState Instance
        {
            get
            {
                if (MMS == null)
                {
                    MMS = new MainMenuState();
                }

                return MMS;
            }
        }


        public override void Enter(GameView _Entity)
        {
            this.CurrentlySelectedOption = 0;
            this.OptionsCount = this.Options.Length;
        }

        // http://rbwhitaker.wikidot.com/monogame-drawing-text-with-spritefonts
        // https://www.dafont.com/top.php

        public override void Excecute(GameView _Entity)
        {
            _Entity.GraphicsDevice.Clear(Color.CornflowerBlue);

            _Entity.spriteBatch.Begin();

            int y = 100;
            int ySpacing = 40;
            Color c;

            foreach (Enum e in Options)
            {
                if (e.Equals(Options[CurrentlySelectedOption]))
                    c = Color.Yellow;
                else
                    c = Color.Black;

                DrawString(_Entity, 0, y, e.ToString(), true, c);

                y += ySpacing;
            }

            _Entity.spriteBatch.End();
        }

        public override void Exit(GameView _Entity)
        {
        }

        public State<GameView> GetSelectedState()
        {
            switch(Options[CurrentlySelectedOption])
            {
                case SelectedOption.Start:
                    return GameState.Instance;
                case SelectedOption.Options:
                    return OptionsState.Instance;
                case SelectedOption.Highscores:
                    return HighscoreState.Instance;
                default:
                    return null;
            }
        }

        public void ChangeSelectedOptionUp()
        {
            CurrentlySelectedOption -= 1;

            if (CurrentlySelectedOption < 0)
                CurrentlySelectedOption = OptionsCount - 1;
        }

        public void ChangeSelectedOptionDown()
        {
            CurrentlySelectedOption += 1;

            if (CurrentlySelectedOption >= OptionsCount)
                CurrentlySelectedOption = 0;
        }
    }
}
