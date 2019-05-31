using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba.Models
{
    public class IncorrectLab1DataException : System.Exception
    {
        public IncorrectLab1DataException() { }
        public IncorrectLab1DataException(string message) : base(message) { }
        public IncorrectLab1DataException(string message, System.Exception inner) : base(message, inner) { }
        protected IncorrectLab1DataException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
