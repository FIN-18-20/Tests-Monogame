﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class UpCommand : ICommands
    {
        Mario mario;
        public UpCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Jump();
        }
    }
}