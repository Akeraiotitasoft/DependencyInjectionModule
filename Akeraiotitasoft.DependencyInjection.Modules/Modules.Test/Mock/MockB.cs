using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Test.Mock
{
    public class MockB : IB
    {
        public string GetMessage()
        {
            return "Hello World!";
        }
    }
}
