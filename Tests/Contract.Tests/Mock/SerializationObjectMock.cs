using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routindo.Contract.Tests.Mock
{
    class SerializationObjectMock
    {
        public string StringProperty { get; set; }

        public int IntegerProperty { get; set; }

        public ChildSerializationObjectMock ChildProperty { get; set; }
    }

    class ChildSerializationObjectMock
    {
        public string StringProperty { get; set; }

        public int IntegerProperty { get; set; }
    }
}
