﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public interface IPipeState
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Eat(Mario mario, Pipe pipe);
        void Puke(Mario mario, Pipe pipe);
        void Chew(Mario mario);
        void Gag(Mario mario);
        Rectangle GetBoundingBox(Vector2 location);
    }
}