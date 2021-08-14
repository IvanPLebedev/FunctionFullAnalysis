using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FunctionFullAnalysis.Differentiators;


namespace FunctionFullAnalysis.Solver.SolversMethods
{
    class NewtonsMethod : ISolverMethodOnSegment
    {
        private IDifferentiator _differentiator;
        public NewtonsMethod(IDifferentiator differentiator)
        {
            _differentiator = differentiator;
        }
        public double GetSolution(Expression<Func<double, double>> function, double a, double b, double eps)
        {
            var f = function.Compile();
            var dif = _differentiator.Run(function);
            var fl = dif.Compile();
            var x0 = 2 * eps + a;
            var x1 = a;
            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = x0 - (f(x0) / fl(x0));
            }
            return x1;
        }
    }
}
