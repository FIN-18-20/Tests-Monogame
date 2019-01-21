using System;
using System.Collections.Generic;
using System.Text;
using GOTY.ECS.Components;

namespace GOTY.ECS.Managers
{
	public class EntityManager
	{
		private List<uint> _entitiesList;

        public EntityManager()
        {
            _entitiesList = new List<uint>();
        }

		public void AddEntity()
		{
			throw new NotImplementedException();
		}

		public void RemoveEntity()
		{
			throw new NotImplementedException();
		}

		public void AttachComponent(Entity entity, IComponent component)
		{
			throw new NotImplementedException();
		}

		public void RemoveComponent(Entity entity, IComponent component)
		{
			throw new NotImplementedException();
		}
	}

    public struct Entity
    {
        public uint Id { get; private set; }

        internal Entity(uint id)
        {
            Id = id;
        }
    }
}
