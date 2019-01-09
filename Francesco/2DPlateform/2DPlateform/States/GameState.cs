using _2DPlateform.Models;
using _2DPlateform.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlateform.States
{
    public class GameState : State
    {
        private SpriteFont _font;

        private List<Player> _players;

        private List<Sprite> _sprites;

        private KeyboardState _currentKey;
        private KeyboardState _previousKey;

        private bool _showBorders = false;

        public GameState(Game1 game, ContentManager content)
          : base(game, content)
        {
        }

        public override void LoadContent()
        {
            Texture2D playerTexture = _content.Load<Texture2D>("Player/player_Square");
            Texture2D bulletTexture = _content.Load<Texture2D>("Bullet");

            _font = _content.Load<SpriteFont>("Font");

            _sprites = new List<Sprite>()
            {
                new Sprite(_game.graphics.GraphicsDevice, _content.Load<Texture2D>("Background/Game"))
                {
                    Layer = 0.0f,
                    Position = new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2),
                },
                /*new Ground(_game.graphics.GraphicsDevice, _content.Load<Texture2D>("Environment/grass"))
                {
                     Position = new Vector2(300, 400),
                     Layer = 0.3f,
                },
                new Ground(_game.graphics.GraphicsDevice, _content.Load<Texture2D>("Environment/grass"))
                {
                     Position = new Vector2(100, 450),
                     Layer = 0.3f,
                },*/
                new Ground(_game.graphics.GraphicsDevice, _content.Load<Texture2D>("Environment/grass"))
                {
                     Position = new Vector2(200, 500),
                     Layer = 0.3f,
                },
            };

            Bullet bulletPrefab = new Bullet(_game.graphics.GraphicsDevice, bulletTexture);


                _sprites.Add(new Player(_game.graphics.GraphicsDevice, playerTexture)
                {
                    Position = new Vector2(200, 400),
                    Layer = 0.3f,
                    Bullet = bulletPrefab,
                    Input = new Input()
                    {
                        Left = Keys.A,
                        Right = Keys.D,
                        Jump = Keys.W,
                        Shoot = Keys.Enter,
                    },
                    Health = 10,
                });

            _players = _sprites.Where(c => c is Player).Select(c => (Player)c).ToList();
        }

        public override void Update(GameTime gameTime)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();


            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.Exit();

            foreach (var sprite in _sprites)
            {
                if(sprite is Player)
                    ((Player)sprite).Update(gameTime, _sprites);
                else
                    sprite.Update(gameTime);
            }

            if (_previousKey.IsKeyDown(Keys.F1) && _currentKey.IsKeyUp(Keys.F1))
                _showBorders = !_showBorders;
        }

        public override void PostUpdate(GameTime gameTime)
        {
            var collidableSprites = _sprites.Where(c => c is ICollidable);

            foreach (Sprite spriteA in collidableSprites)
            {
                foreach (Sprite spriteB in collidableSprites)
                {
                    if (spriteA == spriteB)
                        continue;

                    if (!spriteA.CollisionArea.Intersects(spriteB.CollisionArea))
                        continue;

                    if (spriteA.Intersects(spriteB))
                        ((ICollidable)spriteA).OnCollide(spriteB);
                }
            }

            // Add the children sprites to the list of sprites (ex: bullets)
            int spriteCount = _sprites.Count;
            for (int i = 0; i < spriteCount; i++)
            {
                Sprite sprite = _sprites[i];
                foreach (Sprite child in sprite.Children)
                    _sprites.Add(child);

                sprite.Children = new List<Sprite>();
            }

            // Remove all IsRemoved sprites
            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack);

            foreach (var sprite in _sprites)
            {
                sprite.ShowRectangle = _showBorders;
                sprite.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
