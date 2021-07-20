using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionFullAnalysis.Solver.SolversMethods
{
    interface ISolverMethodOnSegment
    {
        public double GetSolution(Expression<Func<double, double>> function, double a, double b, double eps);
    }
}
