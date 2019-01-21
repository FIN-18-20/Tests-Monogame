using System;
using System.Collections.Generic;
using System.Text;

namespace GOTY.ECS.Components
{
	public class PositionComponent : IComponent
	{
		public int X { get; set; }

		public int Y { get; set; }

        public PositionComponent() : this(0,0) { }

        public PositionComponent(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
