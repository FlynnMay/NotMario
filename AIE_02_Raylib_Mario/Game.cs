using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_02_Raylib_Mario
{
    class Game
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "Mario Walkthrough";

        Texture2D marioTexture;
        Texture2D marioTextureRight;
        Texture2D marioTextureLeft;
        float marioXPos = 400;
        float marioYPos = 200;
        float marioWidth = 32;
        float marioHeight = 32;
        
        float marioVelocity = 10;
        float jumpForce = 20;
        float resetJumpForce = 20;
        float gravity = 10;
        public void LoadGame()
        {
            // TODO: Load game assets here
            marioTextureRight = Raylib.LoadTexture("./assets/mario_1.png");
            marioTextureLeft = Raylib.LoadTexture("./assets/mario_2.png");
            marioTexture = marioTextureRight;
        }

        public void Update(float deltaTime)
        {
            // TODO: Update related logic here
            // jump
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                marioYPos -= jumpForce;
                jumpForce -= 1;
            }

            // movement
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                marioXPos += marioVelocity;
                marioTexture = marioTextureRight;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                marioXPos -= marioVelocity;
                marioTexture = marioTextureLeft;
            }

            // horizontal boundary teleport
            if (marioXPos < 0)
            {
                marioXPos = windowWidth;
            }
            if (marioXPos > windowWidth)
            {
                marioXPos = 0;
            }

            // mario gravity
            marioYPos += gravity;

            if (marioYPos > windowHeight)
            {
                marioYPos = windowHeight;
                jumpForce = resetJumpForce;
            }


            // vertical boundary teleport
            /*            if (marioYPos < 0)
                        {
                            marioYPos = windowHeight;
                        }
                        if (marioYPos > windowHeight)
                        {
                            marioYPos = 0;
                        }*/
        }

        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);

            // TODO: Drawing related logic here

            // draws some text
            Raylib.DrawText("Not Mario", 10, 10, 32, Color.DARKGRAY);

            // draws a rotating texture in center of screen
            RayLibExt.DrawTexture(marioTexture, marioXPos, marioYPos, marioWidth, marioHeight,
                Color.WHITE, 0, 0.5f, 1.0f);

            Raylib.EndDrawing();
        }
    }
}
