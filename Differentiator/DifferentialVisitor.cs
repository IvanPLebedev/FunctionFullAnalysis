using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace FunctionFullAnalysis.Differentiator
{
    class DifferentialVisitor : ExpressionVisitor
    {
        private readonly MethodInfo _pow = typeof(Math).GetMethod(nameof(Math.Pow));
        private readonly MethodInfo _sin = typeof(Math).GetMethod(nameof(Math.Sin));
        private readonly MethodInfo _cos = typeof(Math).GetMethod(nameof(Math.Cos));
        private readonly MethodInfo _log = typeof(Math).GetMethod(nameof(Math.Log), new[] { typeof(double) });
        private readonly ConstantExpression _zero = Expression.Constant(0d, typeof(double));
        private readonly ConstantExpression _one = Expression.Constant(1d, typeof(double));

        public Expression<Func<double, double>> GetDerivative(Expression<Func<double, double>> function)
        {
            return Expression.Lambda<Func<double, double>>(Visit(function.Body), function.Parameters);
        }
        private Expression Differntial(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitConstant(ConstantExpression _) => _zero;

        protected override Expression VisitParameter(ParameterExpression _) => _one;

        protected override Expression VisitBinary(BinaryExpression binaryExpr)
        {
            switch (binaryExpr.NodeType) 
            {
                case ExpressionType.Add:
                    return Expression.Add(Differntial(binaryExpr.Left), Differntial(binaryExpr.Right));  
                case ExpressionType.Subtract:
                    return Expression.Subtract(Differntial(binaryExpr.Left), Differntial(binaryExpr.Right));
                case ExpressionType.Multiply:
                    return Expression.Add(Expression.Multiply(Differntial(binaryExpr.Left), binaryExpr.Right), Expression.Multiply(binaryExpr.Left, Differntial(binaryExpr.Right)));
                case ExpressionType.Divide:
                    return Expression.Divide(
                        Expression.Subtract(
                            Expression.Multiply(Differntial(binaryExpr.Left), binaryExpr.Right), 
                            Expression.Multiply(binaryExpr.Left, Differntial(binaryExpr.Right))), 
                        Expression.Multiply(binaryExpr.Right, binaryExpr.Right));
            }
            throw new NotImplementedException($"Метод {binaryExpr.NodeType} не реализован"); 
        }

        protected override Expression VisitMethodCall(MethodCallExpression methodCall)
        {
            if (methodCall.Method.DeclaringType == typeof(Math))
            {
                var x = methodCall.Arguments[0];
                switch (methodCall.Method.Name)
                {
                    case nameof(Math.Sin):
                        return Expression.Multiply(Expression.Call(null, _cos, x), Differntial(x));
                    case nameof(Math.Cos):
                        return Expression.Negate(Expression.Multiply(Expression.Call(null, _sin, x), Differntial(x)));
                }
            }

            throw new NotImplementedException($"Метод {methodCall.Method.Name} не реализован");
        }
    }
}
