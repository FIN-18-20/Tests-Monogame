using System;
using System.Collections.Generic;
using System.Management.Instrumentation;
using System.Text;
using GOTY.ECS.Components;

namespace GOTY.ECS.Managers
{
	public class EntityManager
    {
        public static int MAX_ENTITIES = 1024;

		private Entity[] _entities;
        private uint _currentId;

        public EntityManager()
        {
            _entities = new Entity[MAX_ENTITIES];
            _currentId = 0;
        }

        /// <summary>
        /// Add an <see cref="Entity"/> to the world.
        /// </summary>
        /// <returns>The newly created Entity or <code>null</code> if the maximum number of entities has been reached. <seealso cref="MAX_ENTITIES"/></returns>
		public Entity AddEntity()
		{
            /* Take the first id available */
            for (uint i = 0; i <= _currentId; i++)
            {
                if (_entities[i] == null)
                {
                    _entities[i] = new Entity(i);
                    return _entities[i];
                }
            }

            if (++_currentId + 1 >= MAX_ENTITIES) // If the max number of entities has been reached, return null
                return null;

            _entities[_currentId] = new Entity(_currentId); // If no ids are available take the next id in array
            return _entities[_currentId];
        }

        /// <summary>
        /// Removes the given <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> to be removed</param>
        /// <returns><c>True</c>if the <see cref="Entity"/> has been removed, <c>false</c> otherwise</returns>
		public bool DestroyEntity(Entity entity)
        {
            if (entity != null && entity.Id < MAX_ENTITIES)
            {
                _entities[entity.Id] = null;
                return true;
            }
            else
                return false;
        }

		public void AttachComponent<T>(Entity entity, T component) where T : class, IComponent, new()
        {
            ComponentManager<T>.Instance.AddComponent(entity, component);
        }

		public void RemoveComponent(Entity entity, IComponent component)
		{
			throw new NotImplementedException();
		}
	}

    public class Entity
    {
        public uint Id { get; private set; }

        private Entity() {}

        internal Entity(uint id)
        {
            Id = id;
        }
    }
}
