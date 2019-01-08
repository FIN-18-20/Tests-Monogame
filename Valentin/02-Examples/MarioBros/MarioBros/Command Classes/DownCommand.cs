﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    public class DownCommand : ICommands
    {
        Mario mario;
        public DownCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Crouch();
        }
    }
}
