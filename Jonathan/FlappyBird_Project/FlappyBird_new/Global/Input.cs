using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird_new
{
    public class Input
    {
        // FIELDS
        private KeyboardState oldKeyboard;
        private MouseState oldMouse;

        private KeyboardState keyboard;
        private MouseState mouse;

        // CONSTRUCTOR
        public Input(KeyboardState oldKeyboard, MouseState oldMouse, KeyboardState keyboard, MouseState mouse)
        {
            this.oldKeyboard = oldKeyboard;
            this.oldMouse = oldMouse;

            this.keyboard = keyboard;
            this.mouse = mouse;
        }

        // METHODS
        public bool IsKey(Keys key)
        {
            return this.oldKeyboard.IsKeyUp(key) && this.keyboard.IsKeyDown(key);
        }

        public bool IsLeftMouseDown()
        {
            return this.mouse.LeftButton == ButtonState.Pressed;
        }

        public bool IsLeftMousePressed()
        {
            return this.oldMouse.LeftButton == ButtonState.Pressed && this.mouse.LeftButton == ButtonState.Released;
        }

        public Point GetMousePosition()
        {
            return new Point(this.mouse.X, this.mouse.Y);
        }
    }
}
