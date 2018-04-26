using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomouslyMovingGameAgents.Tools
{
    public static class VectorMath
    {
        public static Vector2 Truncate(Vector2 v1, float maX)
        {
            if (v1.Length() > maX)
            {
                Vector2 v2 = v1;
                v2.Normalize();
                v2 = v2 * maX;

                return v2;
            }
            return v1;
        }

        public static Vector2 Perp(Vector2 v1)
        {
            return new Vector2(-v1.Y, v1.X);
        }

        public static Vector2 WrapAround(Vector2 pos, int MaxX, int MaxY)
        {
            if (pos.X > MaxX) { pos.X = 0; }

            if (pos.X < 0) { pos.X = MaxX; }

            if (pos.Y < 0) { pos.Y = MaxY; }

            if (pos.Y > MaxY) { pos.Y = 0; }

            return pos;
        }

        public static float VectorToAngle(Vector2 vector)
        {
            return (float)Math.Atan2(vector.X, -vector.Y);
        }
    }
}
