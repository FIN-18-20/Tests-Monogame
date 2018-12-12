using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2PlayersPongGame.Sprites
{
    public class Ball : Sprite
    {
        private float _timer = 0f; // incrémenter la vitesse en fonction de la durée de la partie
        private Vector2? _startPosition = null;
        private float? _startSpeed;
        private bool _isPlaying;

        public Score Score;
        public int SpeedIncrementSpan = 10; // tous les combien de temps la vitesse va s'incrémenter (10s)

        public Ball(Texture2D texture) 
            : base(texture)
        {
            Speed = 3f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (_startPosition == null)
            {
                _startPosition = Position;
                _startSpeed = Speed;

                Restart();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _isPlaying = true;
            }

            if (!_isPlaying)
            {
                return;
            }

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > SpeedIncrementSpan)
            {
                Speed++;
                _timer = 0;
            }

            foreach (Sprite sprite in sprites)
            {
                if (sprite == this)
                {
                    continue;
                }

                if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
                {
                    this.Velocity.X = -this.Velocity.X;
                }
                if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
                {
                    this.Velocity.X = -this.Velocity.X;
                }

                if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
                {
                    this.Velocity.Y = -this.Velocity.Y;
                }
                if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
                {
                    this.Velocity.Y = -this.Velocity.Y;
                }
            }

            if (Position.Y <= 0 || Position.Y + _texture.Height >= Game1.ScreenHeight) // pour rebondir contre les murs du haut et du bas
            {
                this.Velocity.Y = -this.Velocity.Y;
            }

            if (Position.X <= 0) // joueur de droite gagne 1 point
            {
                Score.Score2++;
                Restart();
            }

            if (Position.X + _texture.Width >= Game1.ScreenWidth) // joueur de gauche gagne 1 point
            {
                Score.Score1++;
                Restart();
            }

            Position += Velocity * Speed;

        }

        public void Restart()
        {
            int direction = Game1.Random.Next(0, 4);

            switch (direction)
            {
                case 0:
                    Velocity = new Vector2(1, 1); // Down - Right
                    break;
                case 1:
                    Velocity = new Vector2(1, -1); // Down - Left
                    break;
                case 2:
                    Velocity = new Vector2(-1, -1); // Up - Left
                    break;
                case 3:
                    Velocity = new Vector2(-1, 1); // Up - Right
                    break;
            }

            Position = (Vector2)_startPosition;
            Speed = (float)_startSpeed;
            _timer = 0;
            _isPlaying = false;
        }
    }
}
