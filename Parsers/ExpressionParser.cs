using System;
using System.Linq;
using System.Linq.Expressions;
using Sprache;
using Sprache.Calc;

namespace FunctionFullAnalysis.Parsers
{
	public class ExpressionParser : ScientificCalculator, IExpressionParser
	{
		private ParameterExpression _X = Expression.Parameter(typeof(double));

		protected internal virtual Parser<Expression> ParameterX =>
			from sign in Parse.Char('x')
			select _X;

		protected override Parser<Expression> Factor =>
			(ParameterX).XOr(base.Factor);

		protected internal virtual Parser<LambdaExpression> LambdaOfX =>
			Expr.End().Select(body => Expression.Lambda<Func<double, double>>(body, _X));

		public virtual Expression<Func<double, double>> ParseExpressionOfX(string text)
		{
			_X = Expression.Parameter(typeof(double));
			return LambdaOfX.Parse(text) as Expression<Func<double, double>>;
		}
	}
}
