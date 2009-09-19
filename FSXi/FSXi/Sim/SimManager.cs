using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSXi.Sim
{
    public class SimManager
    {
        /// <summary>
        /// The singleton object. Note: Initialise() must have been called for
        /// this instance to exist.
        /// </summary>
        public static SimManager Instance
        {
            get { return instance; }
        }
        private static SimManager instance = null;

        /// <summary>
        /// The handle which will receive notifications from SimConnect objects.
        /// </summary>
        private static IntPtr handle;

        /// <summary>
        /// Initialise the singleton with the handle to receive messages from
        /// the FSX application.
        /// </summary>
        /// <param name="wHandle"></param>
        public static void Initialise(IntPtr wHandle)
        {
            handle = wHandle;
            instance = new SimManager();
        }

        /// <summary>
        /// Create a SimController object which allows connection to the FSX
        /// application.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public SimController CreateSimController(string name, uint clientID)
        {
            return new SimController(name, clientID, handle);
        }
    }
}