using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Raylib_cs;


namespace CircleGame
{
    internal class CircleGameManager
    {
        int screenWidth;
        int screenHeight;
        float enemySpawnRate = 2;
        float enemySpawnTimer;
        float timeAlive;


        List<Bullet> bullets = new List<Bullet>();
        public Player player;
        List<Enemy> enemies = new List<Enemy>();


        public CircleGameManager(int _screenWidth, int _screenHeight, float playerSize)
        {
            this.screenWidth = _screenWidth;
            this.screenHeight = _screenHeight;
            this.player = new Player(screenWidth, screenHeight, playerSize);
        }


        public void HandleBullets()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                bullets.Add(new Bullet(this.player.pos, Raylib.GetMousePosition()));
            }

            bullets.RemoveAll(b => b.dead);

            foreach (Bullet bullet in bullets)
            {
                bullet.Draw();
            }
        }

        private void spawEnemies()
        {
            enemySpawnTimer += Raylib.GetFrameTime();
            timeAlive += Raylib.GetFrameTime();

            if (enemySpawnTimer > enemySpawnRate)
            {
                enemies.Add(new Enemy(this.player.pos, new Vector2(new Random().Next(0, screenWidth), new Random().Next(0, screenHeight))));
                enemySpawnTimer = 0;
            }

            if (timeAlive > 10)
            {
                enemySpawnRate -= .5f;
            }
        }

        private void HandleEnemies()
        {
            this.spawEnemies();

            foreach (Enemy enemy in enemies)
            {
                foreach (Bullet bullet in bullets)
                {
                    if (Raylib.CheckCollisionPointCircle(bullet.pos, enemy.pos, 20f))
                    {
                        enemy.dead = true;
                        bullet.dead = true;
                    }
                }
            }

            enemies.RemoveAll(e => e.dead);

            foreach (Enemy enemy in enemies)
            {
                enemy.Update(player.pos);
            }
        }

        private void HandlePlayerDeath()
        {
            foreach(Enemy enemy in enemies)
            {
                if (Raylib.CheckCollisionCircles(player.pos, this.player.playerSize, enemy.pos, 20f))
                {
                    player.dead = true;
                    Console.WriteLine("pp");
                }
            }
        }
        
        public void Update()
        {
            this.HandleEnemies();
            this.HandleBullets();
            this.HandlePlayerDeath();
            this.player.Update();

            Raylib.DrawText(timeAlive.ToString().Substring(0, 1), 0, 0, 30, Color.BLACK);
        }
    }
}
