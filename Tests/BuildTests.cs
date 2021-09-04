using NUnit.Framework;
using System.Linq;
using FunctionFullAnalysis.Utils;
using FunctionFullAnalysis.Parsers;
using FunctionFullAnalysis.Differentiators;
using FunctionFullAnalysis.Solver;
using FunctionFullAnalysis.Solver.SolversMethods;

namespace FunctionFullAnalysis.Tests
{
    [TestFixture]
    class BuildTests
    {
        private IExpressionParser _parser;
        private IDifferentiator _differentiator = new Differentiator();
        private ISolver _solver;

        [SetUp]
        public void SetUp()
        {
            _parser = new ExpressionParser();
            _differentiator = new Differentiator();
            _solver = new FuncSolver(new NewtonsMethod(_differentiator), new SegmentSeparatorWithSolution());
        }

        [Test]
        public void BuildTest()
        {
            var funcExpr = _parser.ParseExpressionOfX("x+2");
            var solutions = _solver.GetSolutionsInSegment(funcExpr, new Segment(-10, 10), 1, 1e-5);
            Assert.IsTrue(solutions.Count() == 1);
            Assert.AreEqual(-2, solutions.First(), 1e-5);
        }
    }
}
