using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FunctionFullAnalysis.Differentiators
{
    interface IDifferentiator
    {
        public Expression<Func<double, double>> Run(Expression<Func<double, double>> function);
    }
}
