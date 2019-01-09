using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlateform.Sprites
{
    public class Creature : Sprite, ICollidable
    {
        public int Health { get; set; }

        public Bullet Bullet { get; set; }

        public float Speed { get; set; }

        public Creature(GraphicsDevice graphics, Texture2D texture)
            : base(graphics, texture)
        {
        }

        public void Shoot(float speed)
        {
            // On ne peut pas tirer si on a pas ajouté de Bullet prefab
            if (Bullet == null)
                return;

            Bullet bullet = Bullet.Clone() as Bullet;
            bullet.Position = this.Position;
            bullet.Colour = this.Colour;
            bullet.Layer = 0.1f;
            bullet.LifeSpan = 5f;
            bullet.Velocity = new Vector2(speed, 0f);
            bullet.Parent = this;

            Children.Add(bullet);
        }

        public virtual void OnCollide(Sprite sprite)
        {
            throw new NotImplementedException();
        }
    }
}
