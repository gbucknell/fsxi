using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace FSXi.Sim
{
    [TestFixture]
    public class SimManagerTest
    {
        [SetUp]
        public void Init()
        {
            // Create a windows form so that we can use its handle for the sim connection
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            IntPtr handle = form.Handle;

            SimManager.Initialise(handle);
            Assert.That(SimManager.Instance, Is.Not.Null, "SimManager singleton initialised");
        }

        [Test]
        public void CreateSimController()
        {
            SimController controller = 
                SimManager.Instance.CreateSimController(new Guid().ToString(), (uint)new Random().Next());
            Assert.That(controller, Is.Not.Null);
        }
    }
}
