using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using FunctionFullAnalysis.Utils;

namespace FunctionFullAnalysis.Solver
{
    class SegmentSeparatorWithSolution
    {
        public static IEnumerable<Segment> GetSegmentsWithSolution(Expression<Func<double, double>> function, Segment domain, double step)
        {
            var a1 = domain.A;
            var b1 = a1 + step;
            while (b1 < domain.B)
            {
                yield return new Segment(a1, b1);
                a1 = b1;
                b1 = a1 + step;
            }
            yield return new Segment(a1, domain.B);
        }
    }
}
