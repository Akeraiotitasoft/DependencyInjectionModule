using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Test.Mock
{
    public class MockA2 : MockA
    {
        public override int MathOperation(int a, int b)
        {
            return base.MathOperation(a, b) + 1;
        }
    }
}
