using Raylib_cs;
using CircleGame;



const int screenWidth = 1050;
const int screenHeight = 620;
const float playerSize = 30f;

Raylib.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");
Raylib.SetTargetFPS(60);

CircleGameManager game = new CircleGameManager( screenWidth, screenHeight, playerSize );

while (!game.player.dead)
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    game.Update();
    Raylib.EndDrawing();
}

Raylib.CloseWindow();