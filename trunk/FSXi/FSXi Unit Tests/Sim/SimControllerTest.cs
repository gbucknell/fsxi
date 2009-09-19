using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace FSXi.Sim
{
    [TestFixture]
    public class SimControllerTest
    {
        private SimController simController = null;

        [SetUp]
        public void Init()
        {
            simController = new SimController(new Guid().ToString(), (uint)new Random().Next(), IntPtr.Zero);
            Assert.That(simController, Is.Not.Null, "SimController instance created.");
        }

        [Test]
        public void Connect()
        {
            bool eventFired = false;
            simController.ConnectEvent += (object source) =>
            {
                Assert.That(source, Is.InstanceOf(typeof(SimController)), "Sender is SimController");
                eventFired = true;
            };

            simController.Connect();
            Assert.That(eventFired, "ConnectEvent fired.");
        }

        [Test]
        public void Disconnect()
        {
            bool eventFired = false;
            simController.DisconnectEvent += (object source) =>
            {
                Assert.That(source, Is.InstanceOf(typeof(SimController)), "Sender is SimController");
                eventFired = true;
            };

            simController.Connect();
            simController.Disconnect();
            Assert.That(eventFired, "DisconnectEvent fired.");
        }

        [TearDown]
        public void Dispose()
        {
            simController.Disconnect();
            simController = null;
        }
    }
}