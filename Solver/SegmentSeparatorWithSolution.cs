using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FunctionFullAnalysis.Utils;

namespace FunctionFullAnalysis.Solver
{
    class SegmentSeparatorWithSolution : ISegmentSeparator
    {
        public IEnumerable<Segment> GetSegmentsWithSolution(Expression<Func<double, double>> function, Segment domain, double step)
        {
            var f = function.Compile();
            var a1 = domain.A;
            var b1 = a1 + step;
            do
            {
                if (f(a1) * f(b1) < 0)
                    yield return new Segment(a1, b1);
                a1 = b1;
                b1 = a1 + step;
            }
            while (b1 < domain.B);  
        }
    }
}
