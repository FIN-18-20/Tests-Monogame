using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class LeftCommand : ICommands
    {
        Mario mario;
        public LeftCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.GoLeft();
        }
    }
}