﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class MenuSelectCommand : ICommands
    {
        GUI menu;
        public MenuSelectCommand(GUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Select();
        }
    }
}