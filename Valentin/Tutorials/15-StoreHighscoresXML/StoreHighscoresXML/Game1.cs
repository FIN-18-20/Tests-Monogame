using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StoreHighscoresXML.Controls;
using StoreHighscoresXML.Managers;
using System;
using System.Linq;

namespace StoreHighscoresXML
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Button _button;

        private SpriteFont _font;

        private int _score;

        private ScoreManager _scoreManager;

        private float _timer;

        public static Random Random;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Random = new Random();

            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _scoreManager = ScoreManager.Load();

            _font = Content.Load<SpriteFont>("Font");

            _button = new Button(Content.Load<Texture2D>("Button"), _font)
            {
                Text = "Click me!",
            };
            _button.Click += Button_Click;

            SetButtonPosition(_button);

            _timer = 5; // 5 secondes par round
        }

        private void Button_Click(object sender, EventArgs e)
        {
            SetButtonPosition((Button)sender);

            _score++;
        }

        private void SetButtonPosition(Button button)
        {
            var x = Random.Next(0, graphics.PreferredBackBufferWidth - button.Rectangle.Width);
            var y = Random.Next(0, graphics.PreferredBackBufferHeight - button.Rectangle.Height);

            button.Position = new Vector2(x, y);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            _timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            // si le round est fini
            if (_timer <= 0)
            {
                SetButtonPosition(_button);

                _scoreManager.Add(new Models.Score()
                    {
                        PlayerName = "Bob",
                        Value = _score,
                    }
                );

                ScoreManager.Save(_scoreManager);

                _timer = 5;
                _score = 0;
            }

            _button.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            _button.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(_font, "Score: " + _score, new Vector2(10, 10), Color.Red);
            spriteBatch.DrawString(_font, "Time: " + _timer.ToString("N2"), new Vector2(10, 30), Color.Red);

            spriteBatch.DrawString(_font, "Highscores:\n" + string.Join("\n", _scoreManager.Highscores.Select(c => c.PlayerName + ": " + c.Value).ToArray()), new Vector2(680, 10), Color.Red);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
