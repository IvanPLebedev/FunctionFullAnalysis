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

        [Test]
        public void Test1()
        {
            var str = "x + 2";
            var func = parser.ParseExpressionOfX(str).Compile();
            var res = func(2);
        }
    }
}
