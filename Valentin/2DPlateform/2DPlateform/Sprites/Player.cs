using _2DPlateform.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlateform.Sprites
{
    public class Player : Creature
    {
        private float _shootTimer = 0f;

        private bool _isJumping = false;

        private float _jumpDuration = 0f;

        private const float _JUMP_TIME = 1f;

        private bool _onGround = false;

        private const float GRAVITY = 4f;

        public bool IsDead
        {
            get
            {
                return Health <= 0;
            }
        }

        public Input Input;

        public Player(GraphicsDevice graphics, Texture2D texture)
            : base(graphics, texture)
        {
            Speed = 3f;
        }

        public void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _onGround = false;

            if (IsDead)
                return;

            Velocity = Vector2.Zero;
            _rotation = 0;

            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X -= Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X += Speed;
            }

            _shootTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // On peut laisser appuyer pour tirer mais ça ne tire que 4x par seconde max
            if (Keyboard.GetState().IsKeyDown(Input.Shoot) && _shootTimer > 0.25f)
            {
                Shoot(Speed * 2);
                _shootTimer = 0f;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Jump) && _jumpDuration == 0f)
            {
                _isJumping = true;
            }

            if(_isJumping)
            {
                Jump(gameTime);
            }

            /*foreach (Sprite sprite in sprites)
            {
                if (sprite == this)
                {
                    continue;
                }

                if ((this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) ||
                    (this.Velocity.X < 0 && this.IsTouchingRight(sprite)))
                {
                    Console.WriteLine("------------------------1");
                    this.Velocity.X = 0;
                }

                if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
                {
                    Console.WriteLine("********2");
                    this.Velocity.Y = 0;
                }
                if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))   
                {
                    Console.WriteLine("3");
                    this.Velocity.Y = 0;
                }
                else // tombe
                {
                    this.Velocity.Y++;
                }
            }*/

            foreach (Sprite spriteA in sprites)
            {
                foreach (Sprite spriteB in sprites)
                {
                    if (!(spriteA is ICollidable) || !(spriteB is ICollidable))
                        continue;

                    if (spriteA == spriteB)
                        continue;

                    if (spriteA.CollisionArea.Intersects(spriteB.CollisionArea))
                    {
                        CheckCollisions(spriteB);
                    }
                       

                    /*if (spriteA.Intersects(spriteB))
                        ((ICollidable)spriteA).OnCollide(spriteB);*/
                }
            }

            //Gravité
            if(!_onGround)
                Velocity.Y += GRAVITY;

            Position += Velocity;

            Position = Vector2.Clamp(Position, new Vector2(0, 0), new Vector2(Game1.ScreenWidth, Game1.ScreenHeight));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (IsDead)
                return;

            base.Draw(gameTime, spriteBatch);
        }


        private void CheckCollisions(Sprite sprite)
        {
            if (IsTouchingBottom(sprite))
            {
                Velocity.Y = 0;
            }

            if (IsTouchingTop(sprite) && sprite is Ground)
            {
                _onGround = true;
            }
            else if (IsTouchingLeft(sprite) || IsTouchingRight(sprite))
            {
                Console.WriteLine("Here");
                Velocity.X = 0;
            }
        }

        public override void OnCollide(Sprite sprite)
        {
            if (IsDead)
                return;
        }

        private void Jump(GameTime gameTime)
        {
            _jumpDuration += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_jumpDuration <= _JUMP_TIME / 2)
            {
                _onGround = true;
                Velocity += new Vector2(0, -4);
            }
            else if (_jumpDuration <= _JUMP_TIME)
            {
                //Velocity += new Vector2(0, 4);
            }
            else
            {
                _isJumping = false;
                _jumpDuration = 0f;
            }
        }
    }
}
