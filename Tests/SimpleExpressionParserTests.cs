using NUnit.Framework;
using System;
using System.Linq.Expressions;
using FunctionFullAnalysis.Parsers;

namespace FunctionFullAnalysis.Tests
{
    [TestFixture]
    class SimpleExpressionParserTests
    {
        private SimpleExpressionParser parser = new SimpleExpressionParser();

        [Test]
        public void Test1()
        {
            var str = "x+2";
            var func = parser.ParseExpression(str).Compile();
            var res = func(2);
        }
    }
}
