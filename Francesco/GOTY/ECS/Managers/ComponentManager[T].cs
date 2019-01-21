using System;
using System.Collections.Generic;
using System.Text;

namespace GOTY.ECS.Managers
{
	public class ComponentManager<T>
	{
		private Dictionary<uint, T> _componentsList;

        public ComponentManager()
        {
            _componentsList = new Dictionary<uint, T>();
        }

		public void AddComponent(Entity entity, T component)
		{
            if (!_componentsList.ContainsKey(entity.Id))
            {
                _componentsList.Add(entity.Id, component);
            }
            else
            {
                _componentsList[entity.Id] = component;
            }
		}

		public void RemoveComponent(Entity entity)
        {
            if (_componentsList.ContainsKey(entity.Id))
                _componentsList.Remove(entity.Id);
        }

		public T GetComponent(Entity entity)
        {
            return _componentsList[entity.Id];
        }
	}
}
