using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_TUTO_5
{
    class Sprite
    {
        private Texture2D _texture;
        private float _rotation;

        public Vector2 Position;
        public Vector2 Origin;

        public float RotationVelocity = 3f;
        public float LinearVelocity = 4f;

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                _rotation -= MathHelper.ToRadians(RotationVelocity);
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                _rotation += MathHelper.ToRadians(RotationVelocity);

            var direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));


            if(Keyboard.GetState().IsKeyDown(Keys.Up))
                Position += direction * LinearVelocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, _rotation, Origin, 1, SpriteEffects.None, 0f);
        }
    }
}
