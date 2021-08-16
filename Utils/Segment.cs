using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionFullAnalysis.Utils
{
    class Segment
    {
        public Segment(double a, double b)
        {
            A = a;
            B = b;
        }
        public double A { get; }
        public double B { get; }
    }
}
