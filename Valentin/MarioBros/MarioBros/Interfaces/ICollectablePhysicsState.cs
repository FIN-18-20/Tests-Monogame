using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public interface ICollectablePhysicsState
    {
        void Update(ICollectable item, GameTime gameTime);
    }
}