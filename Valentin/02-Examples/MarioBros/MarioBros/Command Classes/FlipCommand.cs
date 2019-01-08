using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class FlipCommand : ICommands
    {
        Mario mario;
        public FlipCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.physState.Flip();
        }
    }
}