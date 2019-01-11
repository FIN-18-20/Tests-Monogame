using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird_new
{
    public class Button : GameObject
    {
        // FIELDS
        private bool hover;
        private bool isPressed;

        // GETTER
        public bool IsPressed()
        {
            bool result = this.isPressed;

            if (this.isPressed)
                this.isPressed = false;

            return result;
        }

        // CONSTRUCTOR
        public Button(int x, int y, int index)
            : base(x, y, new AnimatedSprite("menu_buttons", 40, 14, index, SheetOrientation.VERTICAL))
        {
            this.hover = false;
            this.isPressed = false;
        }

        // METHODS

        // UPDATE & DRAW
        public override void Update(GameTime gameTime, Input input)
        {
            if (this.hitbox.Contains(input.GetMousePosition()))
            {
                if (input.IsLeftMousePressed())
                {
                    this.isPressed = true;
                    Resources.Sounds["button_clic"].Play();
                }

                if (input.IsLeftMouseDown())
                    this.sprite.SetColor(Color.Gray);
                else
                {
                    this.sprite.SetColor(Color.LightGray);
                    if (this.hover == false)
                        Resources.Sounds["button_hover"].Play();
                }
                this.hover = true;
            }
            else
            {
                this.sprite.SetColor(Color.White);
                this.hover = false;
            }

            base.Update(gameTime, input);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        } 
    }
}
