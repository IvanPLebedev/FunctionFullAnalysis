using System;
using System.Linq.Expressions;

namespace FunctionFullAnalysis.Parsers
{
    interface IExpressionParser
    {
        public Expression<Func<double, double>> ParseExpressionOfX(string text);
    }
}
