using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteSheet _spritesheet;
        InvadersWall _invadersWall;
        Ship _ship;

        private int _screenWidth = 0;
        private int _screenHeight = 0;
        private MouseState _oldMouseState;
        private KeyboardState _oldKeyboardState;
        private bool _readyToShoot = true;

        public Game1()
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
            
            _screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            /*  Set the game to 502x700 or screen max if smaller    */
            if (_screenWidth >= 502)
                _screenWidth = 502;
            if (_screenHeight >= 700)
                _screenHeight = 700;

            graphics.PreferredBackBufferWidth = _screenWidth;
            graphics.PreferredBackBufferHeight = _screenHeight;
            graphics.ApplyChanges();

            _spritesheet = new SpriteSheet(spriteBatch, this.Content);

            int paddleX = (_screenWidth - _spritesheet.SHIP.Width) / 10; // Center the image on the start
            int paddleY = _screenHeight - 50;  // Paddle will be 100px from the bottom of the screen
            _ship = new Ship(paddleX, paddleY, _screenWidth, spriteBatch, _spritesheet);
            _invadersWall = new InvadersWall(_spritesheet, new Point(10, 10));
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
            if (!IsActive)
                return;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            /*  Controllers */
            KeyboardState newKeyboardState = Keyboard.GetState();
            MouseState newMouseState = Mouse.GetState();

            /*  Process mouse move  */
            if (_oldMouseState.X != newMouseState.X)
            {
                if (newMouseState.X >= 0 || newMouseState.X < _screenWidth)
                    _ship.MoveTo(newMouseState.X);
            }

            /*  Process left-click  */
            if (newMouseState.LeftButton == ButtonState.Released && _oldMouseState.LeftButton == ButtonState.Pressed && _readyToShoot)
                //TODO

            /*  Process keyboard events */
            if (newKeyboardState.IsKeyDown(Keys.Left))
            {
                _ship.MoveLeft();
            }
            if (newKeyboardState.IsKeyDown(Keys.Right))
            {
                _ship.MoveRight();
            }
            if (_oldKeyboardState.IsKeyUp(Keys.Space) && newKeyboardState.IsKeyDown(Keys.Space) && _readyToShoot)
                //TODO

            _oldMouseState = newMouseState; // this saves the old state      
            _oldKeyboardState = newKeyboardState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred,null,SamplerState.PointWrap);
            _invadersWall.Draw(spriteBatch);
            _ship.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
