﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public interface IBlockState
    {
        void Update(GameTime gameTime, Block block);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Reaction(Block block);
        Rectangle GetBoundingBox(Vector2 location);
    }
}