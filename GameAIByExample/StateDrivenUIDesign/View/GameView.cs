using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using StateDrivenUIDesign.View.ViewStates;
using StateDrivenUIDesign.Controller;
using StateDrivenUIDesign.Model;

namespace StateDrivenUIDesign.View
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameView : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch { get; set; }
        public StateMachine<GameView> StateMachine { get; set; }

        public SpriteFont Font { get; set; }

        public const int Width = 640;
        public const int Height = 480;

        private KeyboardState previousKeyboardState;

        public GameView()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.Window.IsBorderless = false;
            graphics.PreferredBackBufferHeight = Height;
            graphics.PreferredBackBufferWidth = Width;

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

            StateMachine = new StateMachine<GameView>(this);

            StateMachine.CurrentState = MainMenuState.Instance;

            StateMachine.CurrentState.Enter(this);

            IsMouseVisible = true;

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

            Font = Content.Load<SpriteFont>("SpriteFonts/MenuText");
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
            //http://www.gamefromscratch.com/post/2015/06/28/MonoGame-Tutorial-Handling-Keyboard-Mouse-and-GamePad-Input.aspx

            KeyboardState state = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Escape))
            {
                if (!(this.StateMachine.CurrentState is MainMenuState))
                {
                    this.StateMachine.RevertToPreviousState();
                }
            }
                

            // TODO: Add your update logic here

            switch (this.StateMachine.CurrentState)
            {
                case MainMenuState mms:
                    if (state.IsKeyDown(Keys.Up) & !previousKeyboardState.IsKeyDown(Keys.Up))
                    {
                        mms.ChangeSelectedOptionUp();
                    }

                    if (state.IsKeyDown(Keys.Down) & !previousKeyboardState.IsKeyDown(Keys.Down))
                        mms.ChangeSelectedOptionDown();

                    if (state.IsKeyDown(Keys.Enter))
                    {
                        State<GameView> s = mms.GetSelectedState();
                        if (s != null)
                            this.StateMachine.ChangeState(s);
                        else
                            Exit();
                    }
                    break;
                //case GameState gs:
                //case OptionsState ab:

                //    break;
            }

            previousKeyboardState = Keyboard.GetState();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            StateMachine.Update();

            base.Draw(gameTime);
        }
    }
}
