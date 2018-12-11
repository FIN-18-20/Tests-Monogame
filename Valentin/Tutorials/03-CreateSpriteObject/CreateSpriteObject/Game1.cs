using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CreateSpriteObject
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Sprite _sprite1;
        private Sprite _sprite2;
        
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

            // TODO: use this.Content to load your game content here
            Texture2D texture = Content.Load<Texture2D>("hollow");

            _sprite1 = new Sprite(texture);
            _sprite1.Position = new Vector2(100, 100);

            _sprite2 = new Sprite(texture)
            {
                Position = new Vector2(200, 100),
                Speed = 3f,
            };
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            _sprite1.Update();
            _sprite2.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            _sprite1.Draw(spriteBatch);
            _sprite2.Draw(spriteBatch);

            spriteBatch.End();
       
            base.Draw(gameTime);
        }
    }
}
