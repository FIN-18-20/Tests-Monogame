using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class RunCommand : ICommands
    {
        Mario mario;
        public RunCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.physState.Run();
        }
    }
}