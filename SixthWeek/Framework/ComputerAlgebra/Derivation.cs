using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebra
{
    public static class Derivation
    {
        public static Expression MakeDifferentiate(this Expression expression)
        {
            if (expression is BinaryExpression)
            {
                var e = (BinaryExpression)expression;
                switch (e.NodeType.ToString())
                {
                    case "Multiply":
                    {
                        var leftExpression = Expression.Multiply(((BinaryExpression) expression).Left.MakeDifferentiate(),
                            ((BinaryExpression) expression).Right);
                        var rightExpression = Expression.Multiply(((BinaryExpression)expression).Left,
                            ((BinaryExpression)expression).Right.MakeDifferentiate());

                        return Expression.Add(leftExpression, rightExpression);
                    }
                    case "Add":
                        return Expression.Add(((BinaryExpression)expression).Left.MakeDifferentiate(), 
                                              ((BinaryExpression)expression).Right.MakeDifferentiate());
                }

                throw new ArgumentException(expression.ToString());
            }
            else if (expression is ConstantExpression)
            {
                return Expression.Constant(0.0);
            }
            else if (expression is ParameterExpression)
            {
                return Expression.Constant(1.0);
            }
            else if (expression is MethodCallExpression)//sin
            {
                var expr = ((MethodCallExpression)expression).Arguments[0];
                var sinExpression =
                    Expression.Call(typeof(Math).GetMethod("Cos", BindingFlags.Public | BindingFlags.Static), expr);
                return Expression.Multiply(sinExpression, expr);
            }
            else
                throw new ArgumentException(expression.ToString());
        }
        public static Expression<Func<double, double>> Differentiate(this Expression<Func<double, double>> expression)
        {
            var newExpression = expression.Body.MakeDifferentiate();
            return Expression.Lambda<Func<double, double>>
                (newExpression, Expression.Parameter(typeof(double), expression.Parameters[0].Name));
        }

    }
}
