using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooterGame.Sprites
{
    public class Bullet : Sprite, ICollidable
    {
        private float _timer;

        public Explosion Explosion;

        public float LifeSpan { get; set; }

        public Vector2 Velocity { get; set; }

        public Bullet(Texture2D texture)
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= LifeSpan)
                IsRemoved = true;

            Position += Velocity;
        }

        public void OnCollide(Sprite sprite)
        {
            // Bullets ne Collide pas entre elles
            if (sprite is Bullet)
                return;

            // Enemies ne peuvent pas se toucher entre eux
            if (sprite.Parent is Enemy && this.Parent is Enemy)
                return;

            // Players ne peuvent pas se toucher entre eux
            if (sprite.Parent is Player && this.Parent is Player)
                return;

            // Peut pas toucher un joueur s'il est mort
            if (sprite.Parent is Player && ((Player)sprite.Parent).IsDead)
                return;

            if(sprite is Enemy && this.Parent is Player)
            {
                IsRemoved = true;
                AddExplosion();
            }

            if(sprite is Player && this.Parent is Enemy)
            {
                IsRemoved = true;
                AddExplosion();
            }
        }

        public void AddExplosion()
        {
            if (Explosion == null)
                return;

            Explosion explosion = Explosion.Clone() as Explosion;
            explosion.Position = this.Position;

            Children.Add(explosion);
        }
    }
}
