using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOTY.ECS.Components;
using GOTY.ECS.Managers;
using NUnit.Framework;

namespace ECSEngine.Tests.Managers
{   
    [TestFixture]
    class ComponentManagerTests
    {
        [Test]
        public void AddComponent_WhenPositionComponent_Compiles()
        {
            EntityManager manager = new EntityManager();
            Entity e = manager.AddEntity();
            PositionComponent positionComponent = new PositionComponent(0, 0);

            manager.AttachComponent(e, positionComponent);

            Assert.Pass();
        }

        [Test]
        public void GetComponent_WhenPositionComponent_ReturnsValid()
        {
            EntityManager manager = new EntityManager();
            Entity e = manager.AddEntity();
            PositionComponent positionComponent = new PositionComponent(0, 0);

            manager.AttachComponent(e, positionComponent);

            Assert.AreEqual(positionComponent, ComponentManager<PositionComponent>.Instance.GetComponent(e));
        }

        [Test]
        public void GetComponent_WhenNothing_ReturnsNull()
        {
            EntityManager manager = new EntityManager();
            Entity e = manager.AddEntity();

            Assert.IsNull(ComponentManager<PositionComponent>.Instance.GetComponent(e));
        }
    }
}
