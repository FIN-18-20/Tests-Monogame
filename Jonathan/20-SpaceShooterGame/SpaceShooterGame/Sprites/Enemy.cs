using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooterGame.Sprites
{
    public class Enemy : Ship
    {
        private float _timer;

        public float ShootTimer = 1.75f;

        public Enemy(Texture2D texture)
            : base(texture)
        {
            Speed = 2f;
        }

        public override void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= ShootTimer)
            {
                Shoot(-5f);
                _timer = 0;
            }

            Position += new Vector2(-Speed, 0);

            // Si l'Enemy est trop à gauche de l'écran
            if (Position.X < -_texture.Width)
                IsRemoved = true;
        }

        public override void OnCollide(Sprite sprite)
        {
            // crash contre un joueur
            if(sprite is Player && !((Player)sprite).IsDead)
            {
                ((Player)sprite).Score.Value++;

                IsRemoved = true;
            }

            if(sprite is Bullet && sprite.Parent is Player)
            {
                Health--;

                if(Health <= 0)
                {
                    IsRemoved = true;

                    ((Player)sprite.Parent).Score.Value++;
                }
            }
        }
    }
}
