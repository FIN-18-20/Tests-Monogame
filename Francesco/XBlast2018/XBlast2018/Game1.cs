using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace XBlast2018
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private const int BLOCK_WIDTH = 64;
        private const int BLOCK_HEIGHT = 48;
        private const int GRID_WIDTH = 13;
        private const int GRID_HEIGHT = 11;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D _freeBlock;
        Texture2D _indestructibleBlock;
        Texture2D _redRectangle;
        PlayerTextures _playerTexture;
        Directions _previousDirection;
        Vector2 _playerPosition;
        float _playerMoveSpeed;

        Texture2D[,] _grid;

        KeyboardState _currentKeyboardState;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = BLOCK_WIDTH * GRID_WIDTH;
            graphics.PreferredBackBufferHeight = BLOCK_HEIGHT * GRID_HEIGHT;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            _playerTexture = new PlayerTextures(Players.PLAYER1, this.Content);
            _grid = new Texture2D[GRID_HEIGHT, GRID_WIDTH];
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _playerMoveSpeed = 2.0f;
            _previousDirection = Directions.S;
            _playerPosition = new Vector2(BLOCK_WIDTH * GRID_WIDTH / 2, BLOCK_HEIGHT * GRID_HEIGHT / 2);

            _redRectangle = this.Content.Load<Texture2D>("images/misc/redRectangle");

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _freeBlock = this.Content.Load<Texture2D>("images/block/000_iron_floor");
            _indestructibleBlock = this.Content.Load<Texture2D>("images/block/002_dark_block");

            for (int col = 0; col < GRID_HEIGHT; col++)
            {
                for (int row = 0; row < GRID_WIDTH; row++)
                {
                    if (row == 0 || row == GRID_WIDTH - 1 || col == 0 || col == GRID_HEIGHT - 1)
                    {
                        _grid[col, row] = _indestructibleBlock;
                    }
                    else
                    {
                        _grid[col, row] = _freeBlock;
                    }
                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
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
            
            _currentKeyboardState = Keyboard.GetState();

            float nextX = 0, nextY = 0;

            if (_currentKeyboardState.IsKeyDown(Keys.Up))
                nextY -= _playerMoveSpeed;
            if (_currentKeyboardState.IsKeyDown(Keys.Down))
                nextY += _playerMoveSpeed;
            if (_currentKeyboardState.IsKeyDown(Keys.Right))
                nextX += _playerMoveSpeed;
            if (_currentKeyboardState.IsKeyDown(Keys.Left))
                nextX -= _playerMoveSpeed;

            if (IsWalkable(_playerPosition.X + nextX, _playerPosition.Y + nextY))
            {
                _playerPosition.X += nextX;
                _playerPosition.Y += nextY;
            }

                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            for (int col = 0; col < GRID_HEIGHT; col++)
            {
                for (int row = 0; row < GRID_WIDTH; row++)
                {
                    spriteBatch.Draw(_grid[col, row], new Vector2(row * BLOCK_WIDTH, col * BLOCK_HEIGHT), Color.White);
                }
            }

            Directions currentDirection = Directions.Idle;

            if (_currentKeyboardState.IsKeyDown(Keys.Up))
                currentDirection = Directions.N;
            if (_currentKeyboardState.IsKeyDown(Keys.Down))
                currentDirection = Directions.S;
            if (_currentKeyboardState.IsKeyDown(Keys.Right))
                currentDirection = Directions.E;
            if (_currentKeyboardState.IsKeyDown(Keys.Left))
                currentDirection = Directions.W;

            _previousDirection = currentDirection;
            Texture2D currentPlayer = _playerTexture.GetTexture(currentDirection);

            spriteBatch.Draw(currentPlayer, _playerPosition, Color.White);
            spriteBatch.Draw(_redRectangle, _playerPosition, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private bool IsWalkable(float xPos, float yPos)
        {
            int x = (int)xPos / BLOCK_WIDTH;
            int y = ((int)yPos / BLOCK_HEIGHT) + 1;

            return _grid[y, x] == _freeBlock && _grid[y, x + 1] == _freeBlock;
        }
    }
}
