using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class MenuDownCommand : ICommands
    {
        GUI menu;
        public MenuDownCommand(GUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Down();
        }
    }
}