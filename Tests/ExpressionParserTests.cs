using NUnit.Framework;
using System;
using System.Linq.Expressions;
using FunctionFullAnalysis.Parsers;

namespace FunctionFullAnalysis.Tests
{
    [TestFixture]
    class ExpressionParserTests
    {
        private ExpressionParser parser = new ExpressionParser();

        private void AssertSolution(string funcStr, double x, double expectedY)
        {
            var func = parser.ParseExpressionOfX(funcStr).Compile();
            var actualY = func(x);
            Assert.AreEqual(actualY, expectedY, 1e-5);
        }

        private void AssertRootExpressionType(string funcStr, ExpressionType rootExpressionType)
        {
            var expression = parser.ParseExpressionOfX(funcStr);
            Assert.AreEqual(rootExpressionType, expression.Body.NodeType);
        }

        [Test]
        public void FuncIndependentX()
        {
            AssertSolution("4", 2, 4);
            AssertRootExpressionType("4", ExpressionType.Constant);
        }

        [Test]
        public void SimpleFunc1()
        {
            AssertSolution("x", 2, 2);
            AssertRootExpressionType("x", ExpressionType.Parameter);
        }

        [Test]
        public void SimpleFunc2()
        {
            AssertSolution("x+1", 2, 3);
            AssertRootExpressionType("x+1", ExpressionType.AddChecked);
        }

        [Test]
        public void SimpleFunc3()
        {
            AssertSolution("2*x", 1, 2);
            AssertRootExpressionType("2*x", ExpressionType.MultiplyChecked);
        }

        [Test]
        public void SimpleFunc4()
        {
            AssertSolution("2*x-4", 2, 0);
            AssertRootExpressionType("2*x-4", ExpressionType.SubtractChecked);
        }

        [Test]
        public void SimpleFunc5()
        {
            AssertSolution("x+2*2", 2, 6);
            AssertRootExpressionType("x+2*2", ExpressionType.AddChecked);
        }

        [Test]
        public void SinFunc1()
        {
            AssertSolution("Sin(x)", 0, 0);
            AssertRootExpressionType("Sin(x)", ExpressionType.Call);
        }

        [Test]
        public void SinFunc2()
        {
            AssertSolution("Sin(x)", Math.PI / 2, 1);
        }

        [Test]
        public void CosFunc1()
        {
            AssertSolution("Cos(x)", 0, 1);
            AssertRootExpressionType("Cos(x)", ExpressionType.Call);
        }

        [Test]
        public void CosFunc2()
        {
            AssertSolution("Cos(x)", Math.PI / 2, 0);
        }

        [Test]
        public void ComplexFunc1()
        {
            AssertSolution("Cos(x+2-2)+3-2*Sin(x+4-4)", Math.PI / 2, 1);
            AssertRootExpressionType("Cos(x+2-2)+3-2*Sin(x+4-4)", ExpressionType.SubtractChecked);
        }

        [Test]
        public void ComplexFunc2()
        {
            AssertSolution("0+2+Sin(x)", Math.PI, 2);
            AssertRootExpressionType("0+2+Sin(x)", ExpressionType.AddChecked);
        }
    }
}
