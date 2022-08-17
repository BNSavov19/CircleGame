using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Raylib_cs;

namespace CircleGame
{ 
    internal class Player
    {
        int screenWidth, screenHeight;
        public float playerSize;
        float moveSpeed = 4f;
        public Vector2 pos;
        public bool dead = false;

        public Player(int _screenWidth, int _screenHeight, float _playerSize)
        {
            this.screenWidth = _screenWidth;
            this.screenHeight = _screenHeight;
            this.playerSize = _playerSize;
            pos = new Vector2(_screenWidth / 2, _screenHeight / 2);
        }

        public void Draw()
        {
            Raylib.DrawCircle( (int)pos.X , (int)pos.Y, playerSize, Color.RED);
            //Raylib.DrawLine((int)pos.X, (int)pos.Y, Raylib.GetMouseX(), Raylib.GetMouseY(), Color.RED);
        }

        public void UpdatePosition()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            { 
                pos.X -= 1 + moveSpeed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                pos.X += 1 + moveSpeed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                pos.Y += 1 + moveSpeed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                pos.Y -= 1 + moveSpeed;
            }

            pos = Vector2.Clamp(pos, new Vector2(0 + playerSize, 0 + playerSize), new Vector2(this.screenWidth - playerSize, this.screenHeight - playerSize));
        }

        public void Update()
        {
            this.UpdatePosition();
            this.Draw();
        }

    }
}
