using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Raylib_cs;

namespace CircleGame
{
    internal class Bullet
    {

        public Vector2 pos;
        float directionDeg;
        float moveSpeed = 15f;
        float lifetime;
        public bool dead = false;

        public Bullet(Vector2 startPos, Vector2 target)
        {
            directionDeg = (float)Math.Atan2(target.Y - startPos.Y, target.X - startPos.X) * (float)(180 / Math.PI);
            pos = startPos;
        }


        private void HandleLifeTime()
        {
            lifetime += Raylib.GetFrameTime();
            if (lifetime > 3f)
            {
                this.dead = true;
            }
        }

        public void Draw()
        {

            HandleLifeTime();

            pos.X = (float)Math.Cos(Utils.toRadian(directionDeg)) * moveSpeed + pos.X;
            pos.Y = (float)Math.Sin(Utils.toRadian(directionDeg)) * moveSpeed + pos.Y;

            Raylib.DrawCircle((int)pos.X, (int)pos.Y, 6f, Color.BLUE);
        }

    }
}
