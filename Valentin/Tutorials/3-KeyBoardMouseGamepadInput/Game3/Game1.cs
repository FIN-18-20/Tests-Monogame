using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game3
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position;
        Vector2 origin;
        KeyboardState previousState;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true; // show cursor
        }

        protected override void Initialize()
        {
            base.Initialize();
            position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2);
            origin = new Vector2(64, 64);
            previousState = Keyboard.GetState();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = this.Content.Load<Texture2D>("hollow");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            /*KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var key in state.GetPressedKeys())
            {
                sb.Append("Keys: ").Append(key).Append(" pressed ");
            }
            if (sb.Length > 0)
            {
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No Key pressed");
            }

            if (state.IsKeyDown(Keys.Right) && !previousState.IsKeyDown(Keys.Right))
            {
                position.X += 10;
            }
            if (state.IsKeyDown(Keys.Left) && !previousState.IsKeyDown(Keys.Left))
            {
                position.X -= 10;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                position.Y -= 10;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                position.Y += 10;
            }*/

            MouseState mouseState = Mouse.GetState();

            position.X = mouseState.X;
            position.Y = mouseState.Y;

            if (mouseState.RightButton == ButtonState.Pressed)
            {
                Exit();
            }

            base.Update(gameTime);
            //previousState = state;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, origin: origin);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
