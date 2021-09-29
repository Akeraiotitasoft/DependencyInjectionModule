using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Test.Mock
{
    public class MockA : IA
    {
        public virtual int MathOperation(int a, int b)
        {
            return a + b;
        }
    }
}
