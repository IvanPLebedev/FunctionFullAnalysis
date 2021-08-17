using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FunctionFullAnalysis.Utils;

namespace FunctionFullAnalysis.Solver
{
    interface ISegmentSeparator
    {
        IEnumerable<Segment> GetSegmentsWithSolution(Expression<Func<double, double>> function, Segment domain, double step);
    }
}
