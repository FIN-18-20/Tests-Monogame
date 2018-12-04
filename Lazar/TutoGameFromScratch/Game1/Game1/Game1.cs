using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 texturePos;
        KeyboardState previousState;
        float rotation = 0F;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            texturePos = new Vector2(0, 250);
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

            previousState = Keyboard.GetState();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = this.Content.Load<Texture2D>("ETMLUserLogo");

            Window.Title = "They see me rollin'";
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

            texturePos.X += 1;
            if (texturePos.X > this.GraphicsDevice.Viewport.Width)
                texturePos.X = 0;
            rotation += 0.12f;

            // TODO: Add your update logic here

            KeyboardState state = Keyboard.GetState();
            MouseState msState = Mouse.GetState();

            texturePos.X = msState.X;
            texturePos.Y = msState.Y;

            if (msState.RightButton == ButtonState.Pressed)
                rotation += 0.20f;
            if (msState.LeftButton == ButtonState.Pressed)
                rotation -= 0.42f;
            if (msState.MiddleButton == ButtonState.Pressed)
            {
                rotation = 0;
                texturePos.X -= 1;
                Window.Title = "Freeze, HAMMER TIME";
            }
            else
                Window.Title = "They see me rollin'";

            if (state.IsKeyDown(Keys.Escape))
                Exit();

           /* StringBuilder sb = new StringBuilder();
            foreach (var key in state.GetPressedKeys())
                sb.Append("Keys: ").Append(key).Append(" pressed");

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            else
                System.Diagnostics.Debug.WriteLine("No Keys pressed");

            if (state.IsKeyDown(Keys.Up) & !previousState.IsKeyDown(Keys.Up))
                texturePos.Y += -5;
            if (state.IsKeyDown(Keys.Down) & !previousState.IsKeyDown(Keys.Down))
                texturePos.Y += 5;
            if (state.IsKeyDown(Keys.Right))
            {
                rotation += 0.20f;
                texturePos.X += 2;
            }              
            if (state.IsKeyDown(Keys.Left))
            { 
                rotation -= 0.42f;
                texturePos.X -= 3;
            }

            if (state.IsKeyDown(Keys.F))
            {
                rotation = 0;
                texturePos.X -= 1;
                Window.Title = "Freeze, DON'T MOVE";
            }
            else
                Window.Title = "They see me rollin'";

            //previousState = state;

            */

            base.Update(gameTime);
            

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var fps = 1 / gameTime.ElapsedGameTime.TotalSeconds;
            //Window.Title = fps.ToString();

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            //spriteBatch.Draw(texture, texturePos

            spriteBatch.Draw(texture, destinationRectangle: 
                new Rectangle((int)texturePos.X, (int)texturePos.Y, texture.Width, texture.Height),
                rotation:rotation,
                origin: new Vector2(texture.Width/2, texture.Height/2),
                color: Color.White/*,
                effects: SpriteEffects.FlipHorizontally|SpriteEffects.FlipVertically*/);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
