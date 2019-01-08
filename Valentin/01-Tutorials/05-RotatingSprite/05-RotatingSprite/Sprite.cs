using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _05_RotatingSprite
{
    public class Sprite
    {
        private Texture2D _texture;
        private float _rotation;

        public Vector2 Position;
        public Vector2 Origin; // origine de la rotation

        public float RotationVelocity = 3f; // vitesse de rotation
        public float LinearVelocity = 4f; // vitesse de déplacement

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _rotation -= MathHelper.ToRadians(RotationVelocity); // degrés en radians
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _rotation += MathHelper.ToRadians(RotationVelocity);
            }

            // On soustrait 90 degrés psk MonoGame met de passe notre sprite vers la droite alors qu'on le veut vertical
            Vector2 direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - _rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - _rotation));

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Position += direction * LinearVelocity;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, _rotation, Origin, 1, SpriteEffects.None, 0f);
        }
    }
}
