using System;
using System.Linq.Expressions;
using FunctionFullAnalysis.Utils;

namespace FunctionFullAnalysis.Solver.SolversMethods
{
    public interface ISolverMethodOnSegment
    {
        public double GetSolution(Expression<Func<double, double>> function, Segment segment, double eps);
    }
}
