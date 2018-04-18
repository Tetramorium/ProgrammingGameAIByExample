using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using StateDrivenUIDesign.View.ViewStates;
using StateDrivenUIDesign.Controller;

namespace StateDrivenUIDesign.View
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameView : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public StateMachine<GameView> StateMachine { get; set; }

        public GameView()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here

            StateMachine = new StateMachine<GameView>(this);

            StateMachine.CurrentState = MainMenuState.Instance;

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

            switch (this.StateMachine.CurrentState)
            {
                case MainMenuState mms:
                    if (Keyboard.GetState().IsKeyDown(Keys.O))
                        this.StateMachine.ChangeState(GameState.Instance);
                    break;
                case GameState gs:
                    if (Keyboard.GetState().IsKeyDown(Keys.O))
                        this.StateMachine.ChangeState(MainMenuState.Instance);
                    break;
            }

            // TODO: Add your update logic here

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
