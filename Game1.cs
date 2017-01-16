﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoulderDash
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Graphics.Width;
            graphics.PreferredBackBufferHeight = Graphics.Height;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Map.Load();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Graphics.Player = Content.Load<Texture2D>("Player");
            Graphics.Walls = Content.Load<Texture2D>("Walls");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) Player.Move(-1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) Player.Move(1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) Player.Move(0, -1);
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) Player.Move(0, 1);
            // TODO: Add your update logic here
            Player.Update();
            Camera.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            for (int i = 0; i < Map.Width; i++)
                for (int j = 0; j < Map.Height; j++)
                    if (Map.M[i, j] > 0)
                        spriteBatch.Draw(Graphics.Walls, - Camera.Pos + new Vector2(i * Graphics.SpriteSize, j * Graphics.SpriteSize),
                            Graphics.RectByNum(Graphics.Walls, Map.M[i, j]), Color.White);
            spriteBatch.Draw(Graphics.Player, - Camera.Pos + Player.Pos, Graphics.RectByNum(Graphics.Player, Player.Frame), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
