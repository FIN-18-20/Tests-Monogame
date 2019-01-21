using System;
using System.Collections.Generic;
using System.Text;
using GOTY.ECS.Components;

namespace GOTY.ECS.Managers
{
	public class ComponentManager<T> where T : class, IComponent, new()
	{
		private Dictionary<uint, T> _componentsList;

        private static ComponentManager<T> instance;

        private ComponentManager()
        {
            _componentsList = new Dictionary<uint, T>();
        }

        public static ComponentManager<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ComponentManager<T>();
                }
                return instance;
            }
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
            if (_componentsList.ContainsKey(entity.Id))
            {
                T comp = _componentsList[entity.Id];
                return comp;
            }
            else
            {
                return null;
            }
        }
	}
}
