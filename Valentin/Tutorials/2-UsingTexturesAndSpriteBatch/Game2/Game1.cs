using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Texture2D texture2;
        Vector2 texturePos;
        Vector2 texturePos2;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            texturePos = new Vector2(0, 0);
            texturePos2 = new Vector2(0, 0);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = this.Content.Load<Texture2D>("creeper");
            texture2 = this.Content.Load<Texture2D>("hollow");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //spriteBatch.Draw(texture, texturePos, Color.White);
            //spriteBatch.Draw(texture, destinationRectangle: new Rectangle(50, 50, texture.Width + 50, texture.Height + 50));
            //spriteBatch.Draw(texture, destinationRectangle: new Rectangle(0, 0, texture.Width, texture.Height), rotation: -45f); // rotate on top left corner
            /*spriteBatch.Draw(texture, 
                destinationRectangle: new Rectangle(texture.Width/2, texture.Height/2, texture.Width, texture.Height), 
                rotation: -45f, 
                origin: new Vector2(texture.Width/2, texture.Height/2),
                effects: SpriteEffects.FlipHorizontally|SpriteEffects.FlipVertically);*/

            spriteBatch.Draw(texture, texturePos, Color.White);
            spriteBatch.Draw(texture2, destinationRectangle: new Rectangle(0, 0, 150, 150));
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
