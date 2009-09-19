using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.FlightSimulator.SimConnect;
using FSXi.Properties;
using NLog;

namespace FSXi.Sim
{
    public sealed class SimController : ISimController
    {
        public event ConnectEvent ConnectEvent;
        public event DisconnectEvent DisconnectEvent;

        /// <summary>
        /// Logger.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The SimConnect object interacting with FSX.
        /// </summary>
        private SimConnect simConnect = null;

        /// <summary>
        /// Name for the SimConnect object.
        /// </summary>
        private string name;

        /// <summary>
        /// Identifier for this SimConnect client.
        /// </summary>
        private uint clientID;

        /// <summary>
        /// Handle to receive notifications from FSX application.
        /// </summary>
        private IntPtr handle;

        /// <summary>
        /// SimController constructor. This shouldn't be called explicitly,
        /// instead use SimManager.CreateSimController().
        /// </summary>
        public SimController(string name, uint clientID, IntPtr handle)
        {
            this.name = name;
            this.clientID = clientID;
            this.handle = handle;
        }

        /// <summary>
        /// Connect to the FSX application.
        /// </summary>
        public void Connect()
        {
            if (simConnect != null)
            {
                logger.Warn("Attempting to connect SimConnect client when connection already exists.");
                return;
            }

            try
            {
                // Create the SimConnect object
                logger.Trace("Connecting SimConnect client. Name: {0}. ClientID: {1}", name, clientID);
                simConnect = new SimConnect(name, handle, clientID, null, 0);

                // Throw the connected event
                if (ConnectEvent != null)
                    ConnectEvent(this);
            }
            catch (COMException ex)
            {
                logger.ErrorException("Connection to SimConnect server could not be established.", ex);
                throw new SimException("Connection to SimConnect server could not be established.", ex);
            }
        }

        /// <summary>
        /// Disconnect from the FSX application.
        /// </summary>
        public void Disconnect()
        {
            // Dispose the SimConnect object.
            if (simConnect != null)
            {
                simConnect.Dispose();
                simConnect = null;
                logger.Trace("Disconnected SimConnect client. Name: {0}. ClientID: {1}", name, clientID);
            }

            //  Throw the disconnection event
            if (DisconnectEvent != null)
                DisconnectEvent(this);
        }
    }
}