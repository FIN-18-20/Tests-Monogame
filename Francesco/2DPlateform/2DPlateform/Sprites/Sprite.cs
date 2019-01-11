using _2DPlateform.Managers;
using _2DPlateform.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Gui;

namespace _2DPlateform.Sprites
{
    public class Sprite : Component, ICloneable
    {
        protected const float GRAVITY = 1f;

        protected Dictionary<string, Animation> _animations;

        protected AnimationManager _animationManager;

        protected float _layer { get; set; }

        protected Vector2 _origin { get; set; }

        protected Vector2 _position { get; set; }

        public Vector2 Velocity;

        protected float _rotation { get; set; }

        protected float _scale { get; set; }

        protected Texture2D _texture;

        protected Texture2D _rectangleTexture;

        public List<Sprite> Children { get; set; }

        public Color Colour { get; set; }

        public bool IsRemoved { get; set; }

        public bool ShowRectangle { get; set; }

        public float Layer
        {
            get
            {
                return _layer;
            }

            set
            {
                _layer = value;

                if (_animationManager != null)
                    _animationManager.Layer = _layer;
            }
        }

        public Vector2 Origin
        {
            get
            {
                return _origin;
            }

            set
            {
                _origin = value;

                if (_animationManager != null)
                    _animationManager.Origin = _origin;
            }
        }

        public Vector2 Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;

                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                if (_texture != null)
                {
                    return new Rectangle((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
                }

                if (_animationManager != null)
                {
                    Animation animation = _animations.FirstOrDefault().Value;

                    return new Rectangle((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, animation.FrameWidth, animation.FrameHeight);
                }

                throw new Exception("Unknown Sprite");
            }
        }

        public float Rotation
        {
            get
            {
                return _rotation;
            }

            set
            {
                _rotation = value;

                if (_animationManager != null)
                    _animationManager.Rotation = value;
            }
        }

        public readonly Color[] TextureData;

        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Origin, 0)) *
                    Matrix.CreateRotationZ(_rotation) *
                    Matrix.CreateTranslation(new Vector3(Position, 0));
            }
        }

        public Sprite Parent;

        /// <summary>
        /// The area of the sprite that could "potentially" be collided with
        /// </summary>
        public Rectangle CollisionArea
        {
            get
            {
                return new Rectangle(Rectangle.X, Rectangle.Y, MathHelper.Max(Rectangle.Width, Rectangle.Height), MathHelper.Max(Rectangle.Width, Rectangle.Height));
            }
        }

        public Sprite(GraphicsDevice graphics, Texture2D texture)
        {
            _texture = texture;

            Children = new List<Sprite>();

            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            Colour = Color.White;

            TextureData = new Color[_texture.Width * _texture.Height];
            _texture.GetData(TextureData);

            SetRectangleTexture(graphics, texture);
        }

        public Sprite(Dictionary<string, Animation> animations)
        {
            _texture = null;

            Children = new List<Sprite>();

            Colour = Color.White;

            TextureData = null;

            _animations = animations;

            Animation animation = _animations.FirstOrDefault().Value;

            _animationManager = new AnimationManager(animation);

            Origin = new Vector2(animation.FrameWidth / 2, animation.FrameHeight / 2);

            ShowRectangle = false;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, Position, null, Colour, _rotation, Origin, 1f, SpriteEffects.None, Layer);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);

            if (ShowRectangle)
            {
                if (_rectangleTexture != null)
                {
                    spriteBatch.Draw(_rectangleTexture, Position, null, Color.Red, _rotation, Origin, 1f, SpriteEffects.None, Layer + 0.1f);
                }
            }
        }


        /// <summary>
        ///  Per-pixel collision detection (doesn't work with animated sprites)
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        public bool Intersects(Sprite sprite)
        {
            if (this.TextureData == null)
                return false;

            if (sprite.TextureData == null)
                return false;

            // Calculate a matrix which transforms from A's local space into
            // world space and then into B's local space
            var transformAToB = this.Transform * Matrix.Invert(sprite.Transform);

            // When a point moves in A's local space, it moves in B's local space with a
            // fixed direction and distance proportional to the movement in A.
            // This algorithm steps through A one pixel at a time along A's X and Y axes
            // Calculate the analogous steps in B:
            var stepX = Vector2.TransformNormal(Vector2.UnitX, transformAToB);
            var stepY = Vector2.TransformNormal(Vector2.UnitY, transformAToB);

            // Calculate the top left corner of A in B's local space
            // This variable will be reused to keep track of the start of each row
            var yPosInB = Vector2.Transform(Vector2.Zero, transformAToB);

            for (int yA = 0; yA < this.Rectangle.Height; yA++)
            {
                // Start at the beginning of the row
                var posInB = yPosInB;

                for (int xA = 0; xA < this.Rectangle.Width; xA++)
                {
                    // Round to the nearest pixel
                    var xB = (int)Math.Round(posInB.X);
                    var yB = (int)Math.Round(posInB.Y);

                    if (0 <= xB && xB < sprite.Rectangle.Width &&
                        0 <= yB && yB < sprite.Rectangle.Height)
                    {
                        // Get the colors of the overlapping pixels
                        var colourA = this.TextureData[xA + yA * this.Rectangle.Width];
                        var colourB = sprite.TextureData[xB + yB * sprite.Rectangle.Width];

                        // If both pixel are not completely transparent
                        if (colourA.A != 0 && colourB.A != 0)
                        {
                            return true;
                        }
                    }

                    // Move to the next pixel in the row
                    posInB += stepX;
                }

                // Move to the next row
                yPosInB += stepY;
            }

            // No intersection found
            return false;
        }


        public object Clone()
        {
            Sprite sprite = this.MemberwiseClone() as Sprite;

            if (_animations != null)
            {
                sprite._animations = this._animations.ToDictionary(c => c.Key, v => v.Value.Clone() as Animation);
                sprite._animationManager = sprite._animationManager.Clone() as AnimationManager;
            }

            return sprite;
        }

        private void SetRectangleTexture(GraphicsDevice graphics, Texture2D texture)
        {
            List<Color> colours = new List<Color>();

            for (int y = 0; y < texture.Height; y++)
            {
                for (int x = 0; x < texture.Width; x++)
                {
                    if (x == 0 || // left side
                        y == 0 || // top side
                        x == texture.Width - 1 || // right side
                        y == texture.Height - 1) // bottom side
                    {
                        colours.Add(new Color(255, 255, 255, 255)); // white
                    }
                    else
                    {
                        colours.Add(new Color(0, 0, 0, 0)); // transparent
                    }
                }
            }

            _rectangleTexture = new Texture2D(graphics, texture.Width, texture.Height);
            _rectangleTexture.SetData<Color>(colours.ToArray());
        }

        #region Collision
        protected int IsTouchingRight(Sprite sprite)
        {
            if (this.Rectangle.Bottom > sprite.Rectangle.Top &&
                this.Rectangle.Top < sprite.Rectangle.Bottom &&
                    this.Rectangle.Left <= sprite.Rectangle.Right &&
                    this.Rectangle.Left > sprite.Rectangle.Left)
                return sprite.Rectangle.Right - this.Rectangle.Left;
            else return -1;
        }

        public int IsTouchingLeft(Sprite sprite)
        {
            if (this.Rectangle.Bottom > sprite.Rectangle.Top &&
                this.Rectangle.Top < sprite.Rectangle.Bottom &&
                    this.Rectangle.Right >= sprite.Rectangle.Left &&
                    this.Rectangle.Right < sprite.Rectangle.Right)
                return sprite.Rectangle.Left - this.Rectangle.Right;
            else return -1;
        }

        protected int IsTouchingTop(Sprite sprite)
        {
            if (this.Rectangle.Bottom + this.Velocity.Y + GRAVITY >= sprite.Rectangle.Top &&
              this.Rectangle.Bottom - this.Velocity.Y - GRAVITY < sprite.Rectangle.Top &&
              this.Rectangle.Right >= sprite.Rectangle.Left &&
              this.Rectangle.Left <= sprite.Rectangle.Right)
                return sprite.Rectangle.Top - this.Rectangle.Bottom;
            else
                return -1;
        }

        protected int IsTouchingBottom(Sprite sprite)
        {
            if (this.Rectangle.Top <= sprite.Rectangle.Bottom &&
              this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
              this.Rectangle.Right > sprite.Rectangle.Left &&
              this.Rectangle.Left < sprite.Rectangle.Right)
                return sprite.Rectangle.Bottom - this.Rectangle.Top;
            else
                return -1;
        }

        #endregion
    }
}
