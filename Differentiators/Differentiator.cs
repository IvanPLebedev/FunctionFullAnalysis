using System;
using System.Linq.Expressions;

namespace FunctionFullAnalysis.Differentiators
{
    public class Differentiator: IDifferentiator
    {
        private readonly DifferentialVisitor visitor;

        public Differentiator()
        {
            visitor = new DifferentialVisitor();
        }

        public Expression<Func<double, double>> Run(Expression<Func<double, double>> function)
        {
            return visitor.GetDerivative(function);
        }
    }
}
