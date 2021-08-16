using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunctionFullAnalysis.Utils;

namespace FunctionFullAnalysis.Solver.SolversMethods
{
    interface ISolverMethodOnSegment
    {
        public double GetSolution(Expression<Func<double, double>> function, Segment segment, double eps);
    }
}
