using AutonomouslyMovingGameAgents.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AutonomouslyMovingGameAgents.View
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameView : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D Texture_RedCar;

        MouseState PreviousMouseState;

        public Vector2 WindowDimensions { get; set; }

        public GameView()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.Window.IsBorderless = false;
            IsMouseVisible = true;

            this.WindowDimensions = new Vector2(640, 480);

            graphics.PreferredBackBufferWidth = (int)this.WindowDimensions.X;
            graphics.PreferredBackBufferHeight = (int)this.WindowDimensions.Y;

            // http://community.monogame.net/t/how-to-center-gamewindow/9518/5
            Window.Position = new Point((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (graphics.PreferredBackBufferWidth / 2), (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - (graphics.PreferredBackBufferHeight / 2));
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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

            // TODO: use this.Content to load your game content here

            Texture_RedCar = Content.Load<Texture2D>("img/RedCar");
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

            // TODO: Add your update logic here

            MouseState mouseState = Mouse.GetState();

            Vector2 v2 = Vector2.Zero;
            bool clicked = false;

            if (mouseState.LeftButton == ButtonState.Pressed & !(PreviousMouseState.LeftButton == ButtonState.Pressed))
            {
                v2 = new Vector2(mouseState.Position.X, mouseState.Position.Y);
                clicked = true;
            }

            foreach (Vehicle v in GameWorld.Instance.Vehicles)
            {
                v.Update((float)gameTime.ElapsedGameTime.Milliseconds / (25));

                if (clicked)
                {
                    v.Target = v2;
                }
            }

            PreviousMouseState = mouseState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            foreach(Vehicle v in GameWorld.Instance.Vehicles)
            {
                v.Draw(this.spriteBatch, Texture_RedCar);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
