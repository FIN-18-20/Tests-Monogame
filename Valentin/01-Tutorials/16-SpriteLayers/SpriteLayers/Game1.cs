using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpriteLayers
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Vector2 _position1;
        private Vector2 _position2;

        private Texture2D _texture;
        
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

            _position1 = new Vector2(100, 100);
            _position2 = new Vector2(125, 100);

            _texture = Content.Load<Texture2D>("Square");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack); // param à ajouter ici

            spriteBatch.Draw(_texture, _position1, null, Color.Red, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.2f); // dernier arg : layerDepth: float entre 0 et 1
            spriteBatch.Draw(_texture, _position2, null, Color.Blue, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0.1f); // plus il est élevé plus le sprite est en 1er plan

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
