using Microsoft.Xna.Framework;
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
            Graphics.Init();
            Map.Load();
            World.Init();
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
            Graphics.Back = Content.Load<Texture2D>("Back");
            Graphics.Light = Content.Load<Texture2D>("Light");
            Rock.Texture = Content.Load<Texture2D>("Rock");
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
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) World.player1.Move(-1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) World.player1.Move(1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) World.player1.Move(0, -1);
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) World.player1.Move(0, 1);
            // TODO: Add your update logic here
            World.player1.Update();
            Camera.Update();
            World.Update();
            World.Rocks.ForEach(o => o.Update());
            World.Rocks.RemoveAll(o => o.Destroyed);
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
            //spriteBatch.Draw(Graphics.Back, Graphics.Full, Color.White);
            for (int i = 0; i < Map.Width; i++)
                for (int j = 0; j < Map.Height; j++)
                {
                    //if (Map.M[1, i, j] > 0)
                    spriteBatch.Draw(Graphics.Walls, -Camera.Pos + new Vector2(i * Graphics.SpriteSize, j * Graphics.SpriteSize),
                            Graphics.RectByNum(Graphics.Walls, Map.M[0, i, j]), Color.Red);
                    spriteBatch.Draw(Graphics.Walls, -Camera.Pos + new Vector2(i * Graphics.SpriteSize, j * Graphics.SpriteSize),
                            Graphics.RectByNum(Graphics.Walls, Map.M[1, i, j]), Color.White);
                }
            //Игрок
            spriteBatch.Draw(Graphics.Player, World.player1.Pos - Camera.Pos, Graphics.RectByNum(Graphics.Player, World.player1.Frame), Color.White);
            //Объекты
            foreach (Box o in World.Rocks)
                spriteBatch.Draw(Rock.Texture, o.Pos - Camera.Pos, Graphics.RectByNum(Rock.Texture, 1), Color.White);

            spriteBatch.Draw(Graphics.Light, Graphics.Full, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
