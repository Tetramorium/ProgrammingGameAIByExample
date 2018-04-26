using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomouslyMovingGameAgents.Model
{
    public abstract class BaseGameEntity
    {
        private static int id = 0;

        public int Id { get; set; }
        public string Name { get; set; }

        public float Angle { get; set; }

        public Vector2 Location { get; set; }

        public BaseGameEntity(Vector2 _Location, string _Name)
        {
            this.Id = id;
            id++;

            this.Name = _Name;
            this.Location = _Location;
        }

        public abstract void Update(float _TimeElapsed);

        public virtual void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            Rectangle SourceRect = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
            //Vector2 _drawLocation = new Vector2(Location.X + this.Width / 2, Location.Y + this.Height / 2);
            Vector2 _drawLocation = new Vector2(Location.X, Location.Y);
            spriteBatch.Draw(texture, _drawLocation, SourceRect, Color.White, Angle, origin, (float)(20f / texture.Width), SpriteEffects.None, 1.0f);
        }
    }
}
