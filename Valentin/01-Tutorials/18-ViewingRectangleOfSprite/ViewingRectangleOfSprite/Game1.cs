using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using ViewingRectangleOfSprite.Sprites;

namespace ViewingRectangleOfSprite
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private KeyboardState _currentKey;
        private KeyboardState _previousKey;

        private bool _showBorders = false;

        private List<Sprite> _sprites;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _sprites = new List<Sprite>()
            {
                new Sprite(graphics.GraphicsDevice, Content.Load<Texture2D>("Square"))
                {
                    Position = new Vector2(100, 100),
                },
                new Player(graphics.GraphicsDevice, Content.Load<Texture2D>("Apple"))
                {
                    Position = new Vector2(200, 100),
                },
                new Sprite(graphics.GraphicsDevice, Content.Load<Texture2D>("Bomb"))
                {
                    Position = new Vector2(200, 200),
                },
            };
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            if (_previousKey.IsKeyDown(Keys.F1) && _currentKey.IsKeyUp(Keys.F1))
                _showBorders = !_showBorders;

            foreach (Sprite sprite in _sprites)
                sprite.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (Sprite sprite in _sprites)
            {
                sprite.ShowRectangle = _showBorders;
                sprite.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
