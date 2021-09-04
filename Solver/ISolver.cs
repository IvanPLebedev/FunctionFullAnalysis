using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FunctionFullAnalysis.Utils;

namespace FunctionFullAnalysis.Solver
{
    interface ISolver
    {
        IEnumerable<double> GetSolutionsInSegment(Expression<Func<double, double>> function, Segment segment, double miniSegmentsLengs, double eps);
    }
}
