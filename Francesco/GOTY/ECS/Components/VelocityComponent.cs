using System;
using System.Collections.Generic;
using System.Text;

namespace GOTY.ECS.Components
{
	public class VelocityComponent : IComponent
	{
		public int XVelocity { get; set; }

		public int YVelocity { get; set; }

        public VelocityComponent(int xVelocity, int yVelocity)
        {
            XVelocity = xVelocity;
            YVelocity = yVelocity;
        }
    }
}
