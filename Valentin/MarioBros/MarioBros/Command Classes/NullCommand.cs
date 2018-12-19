using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioBros
{
    public class NullCommand : ICommands
    {
        public NullCommand()
        {
        }
        public void Execute()
        {
        }
    }
}