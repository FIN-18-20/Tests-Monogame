using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class MenuUpCommand : ICommands
    {
        GUI menu;
        public MenuUpCommand(GUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Up();
        }
    }
}