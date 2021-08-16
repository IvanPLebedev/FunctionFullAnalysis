using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FunctionFullAnalysis.Differentiators;
using FunctionFullAnalysis.Utils;


namespace FunctionFullAnalysis.Solver.SolversMethods
{
    class NewtonsMethod : ISolverMethodOnSegment
    {
        private IDifferentiator _differentiator;
        public NewtonsMethod(IDifferentiator differentiator)
        {
            _differentiator = differentiator;
        }

        public double GetSolution(Expression<Func<double, double>> function, Segment segment, double eps)
        {
            var f = function.Compile();
            var fl = _differentiator.Run(function).Compile();
            var x0 = 2 * eps + segment.A;
            var x1 = segment.A;
            var n = 0;
            while (Math.Abs(x1 - x0) > eps)
            {
                n++;
                x0 = x1;
                x1 = x0 - (f(x0) / fl(x0));
                if (x1 > segment.B || x1 < segment.A || n > 100)
                    throw new ArgumentException("Not found solution in segment ab.");
            }
            return x1;
        }
    }
}
