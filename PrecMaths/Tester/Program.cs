using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrecMaths;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            PiSymbol s = new PiSymbol(2);
            s.EvaluteString(10);
        }
    }
}
