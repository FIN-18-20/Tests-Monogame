using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
        private _wall _wall;
        private GameBorder _gameBorder;
        private _ball _ball;
        private _ball _staticBall; //used to draw image next to remaining _ball count at top of screen

        private int _screenWidth = 0;
        private int _screenHeight = 0;
        private MouseState _oldMouseState;
        private KeyboardState _oldKeyboardState;
        private bool _readyToServeBall = true;
        private int _remainingBalls = 3;
        private int _currentSongIndex = 0;
        
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
            _wall = new _wall(1, 50, spriteBatch, gameContent);
            _gameBorder = new GameBorder(_screenWidth, _screenHeight, spriteBatch, gameContent);
            _ball = new _ball(_screenWidth, _screenHeight, spriteBatch, gameContent);
            _staticBall = new _ball(_screenWidth, _screenHeight, spriteBatch, gameContent);
            _staticBall.X = 25;
            _staticBall.Y = 25;
            _staticBall.Visible = true;
            _staticBall.UseRotation = false;

            MediaPlayer.Play(gameContent.MusicList[0]);
            MediaPlayer.Volume = 0.3f;
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
            if(_oldMouseState.X != newMouseState.X)
            {
                if (newMouseState.X >= 0 || newMouseState.X < _screenWidth)
                    _paddle.MoveTo(newMouseState.X);
            }

            /*  Process left-click  */
            if (newMouseState.LeftButton == ButtonState.Released && _oldMouseState.LeftButton == ButtonState.Pressed && _readyToServeBall)
                ServeBall();

            /*  Process keyboard events */
            if (newKeyboardState.IsKeyDown(Keys.Left))
            {
                _paddle.MoveLeft();
            }
            if (newKeyboardState.IsKeyDown(Keys.Right))
            {
                _paddle.MoveRight();
            }
            if (_oldKeyboardState.IsKeyUp(Keys.Space) && newKeyboardState.IsKeyDown(Keys.Space) && _readyToServeBall)
                ServeBall();

            _oldMouseState = newMouseState; // this saves the old state      
            _oldKeyboardState = newKeyboardState;

            if(MediaPlayer.State == MediaState.Stopped)
            {
                _currentSongIndex = _currentSongIndex + 1 % gameContent.MusicList.Count;
                MediaPlayer.Play(gameContent.MusicList[_currentSongIndex]);
            }

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
            if (_ball.Visible)
            {
                bool inPlay = _ball.Move(_wall, _paddle);
                if (inPlay)
                {
                    _ball.Draw();
                }
                else
                {
                    _remainingBalls--;
                    _readyToServeBall = true;
                }
            }
            _staticBall.Draw();

            string scoreMsg = "Score: " + _ball.Score.ToString("00000");
            Vector2 space = gameContent.LabelFont.MeasureString(scoreMsg);
            spriteBatch.DrawString(gameContent.LabelFont, scoreMsg, new Vector2((_screenWidth - space.X) / 2, _screenHeight - 40), Color.White);
            if (_ball.bricksCleared >= 70)
            {
                _ball.Visible = false;
                _ball.bricksCleared = 0;
                _wall = new _wall(1, 50, spriteBatch, gameContent);
                _readyToServeBall = true;
            }
            if (_readyToServeBall)
            {
                if (_remainingBalls > 0)
                {
                    string startMsg = "Press <Space> or Click Mouse to Start";
                    Vector2 startSpace = gameContent.LabelFont.MeasureString(startMsg);
                    spriteBatch.DrawString(gameContent.LabelFont, startMsg, new Vector2((_screenWidth - startSpace.X) / 2, _screenHeight / 2), Color.White);
                }
                else
                {
                    string endMsg = "Game Over";
                    Vector2 endSpace = gameContent.LabelFont.MeasureString(endMsg);
                    spriteBatch.DrawString(gameContent.LabelFont, endMsg, new Vector2((_screenWidth - endSpace.X) / 2, _screenHeight / 2), Color.White);
                }
            }
            spriteBatch.DrawString(gameContent.LabelFont, _remainingBalls.ToString(), new Vector2(40, 10), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ServeBall()
        {
            if (_remainingBalls < 1)
            {
                _remainingBalls = 3;
                _ball.Score = 0;
                _wall = new _wall(1, 50, spriteBatch, gameContent);
            }
            _readyToServeBall = false;
            float ballX = _paddle.X + (_paddle.Width) / 2;
            float ballY = _paddle.Y - _paddle.Height;
            _ball.Launch(ballX, ballY, -3, -3);
        }
    }
}
