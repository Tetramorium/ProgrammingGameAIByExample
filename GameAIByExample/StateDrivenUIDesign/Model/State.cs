using Microsoft.Xna.Framework;
using StateDrivenUIDesign.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDrivenUIDesign.Model
{
    //public interface IState<T>
    //{
    //    // Load resources
    //    void Enter(T _Entity);
    //    // Draw
    //    void Excecute(T _Entity);
    //    // Dispose resources
    //    void Exit(T _Entity);
    //}

    public abstract class State<T>
    {
        public abstract void Enter(T _Entity);
        public abstract void Excecute(T _Entity);
        public abstract void Exit(T _Entity);

        public void DrawString(GameView entity, int x, int y, string str, bool isCentered, Color color)
        {
            if (isCentered)
            {
                Vector2 StringWidth = entity.Font.MeasureString(str);
                entity.spriteBatch.DrawString(entity.Font, str, new Vector2(GameView.Width / 2 - StringWidth.X / 2 + x, y), color);
            }
            else
            {
                entity.spriteBatch.DrawString(entity.Font, str, new Vector2(x, y), color);
            }
        }
    }
}
