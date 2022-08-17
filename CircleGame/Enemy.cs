using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Raylib_cs;


namespace CircleGame
{
    internal class Enemy
    {

        public Vector2 pos;
        Vector2 target;
        Vector2 vecToTarget;
        float rotation;
        float moveSpeed = 5f;
        public bool dead = false;

        public Enemy(Vector2 playerPos, Vector2 spawnPos)
        {
            //spawn enemy at random pos

            pos = spawnPos;
            target = playerPos;
        }

        private void Draw()
        {
            Raylib.DrawCircle((int)pos.X, (int)pos.Y, 20f, Color.DARKBLUE);
        }

        public void Update(Vector2 playerPos)
        {
            target = playerPos;
            vecToTarget = Vector2.Subtract(target, pos);
            rotation = (float)Math.Atan2(vecToTarget.Y, vecToTarget.X) * (float)(180 / Math.PI);
            
            pos.X = (float)Math.Cos(Utils.toRadian(rotation)) * moveSpeed + pos.X;
            pos.Y = (float)Math.Sin(Utils.toRadian(rotation)) * moveSpeed + pos.Y;
            
            this.Draw();
        }

        private void deathCheck()
        {
            //check if enemy is hit by bullet
        }

    }
}
