using FunctionFullAnalysis.Utils;
using FunctionFullAnalysis.Solver.SolversMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FunctionFullAnalysis.Solver
{
    public class FuncSolver : ISolver
    {
        private readonly ISolverMethodOnSegment _solverOnSegment;
        private readonly ISegmentSeparator _segmentSeparator;
        public FuncSolver(ISolverMethodOnSegment solverMethodOnSegment, ISegmentSeparator segmentSeparator)
        {
            _solverOnSegment = solverMethodOnSegment;
            _segmentSeparator = segmentSeparator;
        }
        public IEnumerable<double> GetSolutionsInSegment(Expression<Func<double, double>> function, Segment segment, double miniSegmentsLengs, double eps)
        {
            return _segmentSeparator.GetSegmentsWithSolution(function, segment, eps * 100)
                .Select(seg => _solverOnSegment.GetSolution(function, seg, eps));
        }
    }
}
