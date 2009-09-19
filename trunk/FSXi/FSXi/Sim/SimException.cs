using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSXi.Sim
{
    public class SimException : ApplicationException
    {
        public SimException(string message) 
            : base(message) { }

        public SimException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
