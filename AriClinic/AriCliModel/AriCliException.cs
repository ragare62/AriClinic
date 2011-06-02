using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AriCliModel
{
    [Serializable]
    public class AriCliException : System.Exception
    {
        // Constructors
        public AriCliException()
        {
        }
        public AriCliException(string message)
            : base(message)
        {
        }
        public AriCliException(int number, string message)
            : base(message)
        {
            this.number = number;
        }
        public AriCliException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public AriCliException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        //Properties

        private int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
    }
}
