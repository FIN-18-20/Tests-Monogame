using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteDeathAndRespawn.Sprites
{
    public class Player : Sprite
    {
        public bool HasDied = false;

        public Player(Texture2D texture) 
            : base(texture)
        {
            _texure = texture;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            foreach (Sprite sprite in sprites)
            {
                if(sprite is Player) // pas faire une collision avec un Player
                {
                    continue;
                }

                if (sprite.Rectangle.Intersects(this.Rectangle)) // si on touche une bombe
                {
                    this.HasDied = true;
                }
            }

            Position += Velocity;
            Position.X = MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - Rectangle.Width); // Garder le joueur sur l'écran
            Velocity = Vector2.Zero; // reset la velocity quand on n'enfonce plus la touche
        }

        private void Move()
        {
            if (Input == null)
            {
                throw new Exception("Please assign a value to 'Input'");
            }

            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X = Speed;
            }
        }
    }
}
