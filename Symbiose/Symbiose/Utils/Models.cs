using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Symbiose.Utils
{
    public class Models
    {
        public enum ResponseType
        {
            Undefined = 0,
            Succesful = 1,
            Warning = 2,
            Error = 3
        }

        public class Response
        {
            public ResponseType Status { get; set; }

            public string Text { get; set; }

            public object Value { get; set; }
        }
    }
}
