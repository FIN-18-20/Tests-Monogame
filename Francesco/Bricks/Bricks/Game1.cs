﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bricks
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameContent gameContent;

        private Paddle _paddle;
        private Wall _wall;
        private GameBorder _gameBorder;

        private int _screenWidth = 0;
        private int _screenHeight = 0;
        
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

            gameContent = new GameContent(this.Content);

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

            /*  Create game objects */
            int paddleX = (_screenWidth - gameContent.PaddleImg.Width) / 2; // Center the image on the start
            int paddleY = _screenHeight - 100;  // Paddle will be 100px from the bottom of the screen
            _paddle = new Paddle(paddleX, paddleY, _screenWidth, spriteBatch, gameContent);
            _wall = new Wall(1, 50, spriteBatch, gameContent);
            _gameBorder = new GameBorder(_screenWidth, _screenHeight, spriteBatch, gameContent);
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
            _paddle.Draw();
            _wall.Draw();
            _gameBorder.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
