using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Sprache;
using Sprache.Calc;

namespace FunctionFullAnalysis.Parsers
{
    public class ExpressionParser : ScientificCalculator
    {
		private ParameterExpression X = Expression.Parameter(typeof(double));
		
		protected internal virtual Parser<Expression> ParameterX =>
			from sign in Parse.Char('x')
			select X;

		protected override Parser<Expression> Factor =>
			(ParameterX).XOr(base.Factor);

		protected internal virtual Parser<LambdaExpression> LambdaOfX =>
			Expr.End().Select(body => Expression.Lambda<Func<double, double>>(body, X));

		public virtual Expression<Func<double, double>> ParseExpressionOfX(string text) =>
			LambdaOfX.Parse(text) as Expression<Func<double, double>>;
	}
}
