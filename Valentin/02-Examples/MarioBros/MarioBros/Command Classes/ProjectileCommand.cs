using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class ProjectileCommand : ICommands
    {
        Mario mario;
        public ProjectileCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            if (mario.isFire && !mario.isNinja)
            {
                mario.MakeFireballMario();
            }
            if (mario.isNinja)
            {
                mario.MakeNinjaMario();
            }
        }
    }
}