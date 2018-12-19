﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public interface IGameState
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
