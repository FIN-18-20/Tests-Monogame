using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteDeathAndRespawn.Models;
using SpriteDeathAndRespawn.Sprites;
using System;
using System.Collections.Generic;

namespace SpriteDeathAndRespawn
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Random Random;

        public static int ScreenWidth;
        public static int ScreenHeight;

        private List<Sprite> _sprites;

        private float _timer;

        private bool _hasStared = false;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Random = new Random();

            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Restart();
        }

        private void Restart()
        {
            Texture2D playerTexture = Content.Load<Texture2D>("Player");

            _sprites = new List<Sprite>()
            {
                new Player(playerTexture)
                {
                    Position = new Vector2((ScreenWidth / 2) - (playerTexture.Width / 2), ScreenHeight - playerTexture.Height),
                    Input = new Input()
                    {
                        Left = Keys.A,
                        Right = Keys.D,
                    },
                    Speed = 10f,
                }
            };

            _hasStared = false;
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _hasStared = true; // start le jeu
            }

            if (!_hasStared)
            {
                return;
            }

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach(Sprite sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }

            if(_timer > 0.25f) // ajoute une bombe chaque 0.25s
            {
                _timer = 0f;
                _sprites.Add(new Bomb(Content.Load<Texture2D>("Bomb")));
            }

            for (int i = 0; i < _sprites.Count; i++)
            {
                Sprite sprite = _sprites[i];

                if (sprite.IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }

                if (sprite is Player)
                {
                    Player player = sprite as Player;
                    if(player.HasDied)
                    {
                        Restart();
                    }
                }
            }
             
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (Sprite sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
