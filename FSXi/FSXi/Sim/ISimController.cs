using System;
using System.Collections.Generic;
using System.Text;

namespace FSXi.Sim
{
    public delegate void ConnectEvent(object source);
    public delegate void DisconnectEvent(object source);

    /// <summary>
    /// Defines the functions to control the behaviour of the FSX application
    /// as well as the events received from the FSX application.
    /// 
    /// All functions are asynchronous so as to allow notification to multiple
    /// observers (GUI and USB). The corresponding event is the function name
    /// suffixed with 'Event'.
    /// </summary>
    public interface ISimController
    {
        #region Functions

        /// <summary>
        /// Connect to the FSX application.
        /// </summary>
        void Connect();

        /// <summary>
        /// Disconnect from the FSX application.
        /// </summary>
        void Disconnect();
        
        #endregion

        #region Events

        /// <summary>
        /// SimController has connected to the FSX application.
        /// </summary>
        event ConnectEvent ConnectEvent;

        /// <summary>
        /// SimController has disconnected from the FSX application.
        /// </summary>
        event DisconnectEvent DisconnectEvent;

        #endregion
    }
}