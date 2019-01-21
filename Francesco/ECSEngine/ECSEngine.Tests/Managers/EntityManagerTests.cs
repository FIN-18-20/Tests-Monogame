using System;
using System.Text;
using System.Collections.Generic;
using GOTY.ECS.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECSEngine.Tests.Managers
{
    using NUnit.Framework;

    [TestFixture]
    public class EntityManagerTests
    {
        [Test]
        public void AddEntity_ReturnsEntity_Once()
        {
            EntityManager manager = new EntityManager();

            Entity e = manager.AddEntity();

            Assert.AreEqual(0,e.Id);
        }

        [Test]
        public void AddEntity_ReturnsEntity_Twice()
        {
            EntityManager manager = new EntityManager();

            manager.AddEntity();
            Entity e = manager.AddEntity();

            Assert.AreEqual(1, e.Id);
        }

        [Test]
        public void AddEntity_ReturnsEntity_Random([Random(1,1000,5)]int times)
        {
            EntityManager manager = new EntityManager();

            for (int i = 0; i < times - 1; i++)
            {
                manager.AddEntity();
            }

            Entity e = manager.AddEntity();

            Assert.AreEqual(times - 1,e.Id);
        }

        [Test]
        public void RemoveEntity_ReturnsTrue_WhenValid()
        {
            EntityManager manager = new EntityManager();
            Entity e = manager.AddEntity();

            Assert.AreEqual(0, e.Id);

            Assert.IsTrue(manager.DestroyEntity(e));
        }

        [Test]
        public void RemoveEntity_ReturnsFalse_WhenNull()
        {
            EntityManager manager = new EntityManager();
            manager.AddEntity();
            
            Assert.IsFalse(manager.DestroyEntity(null));
        }
    }
}
