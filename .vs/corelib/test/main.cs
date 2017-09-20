using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using corelib.core;

namespace test
{
    class main
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1.0f,2.0f,3.0f);
            Vector v2 = new Vector(1.0f, 2.0f, 3.0f);

            Vector v3 = v1 + v2;
        }
    }
}
