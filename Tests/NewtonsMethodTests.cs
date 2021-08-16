using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FunctionFullAnalysis.Solver.SolversMethods;
using FunctionFullAnalysis.Differentiators;
using FunctionFullAnalysis.Utils;

namespace FunctionFullAnalysis.Tests
{
    [TestFixture]
    class NewtonsMethodTests
    {
        private readonly ISolverMethodOnSegment solver = new NewtonsMethod(new Differentiator());
        private void AssertEqualtionHasSolution(Expression<Func<double, double>> equaltion, double segmentStart, double segmentEnd, double expectedSolution, double eps)
        {
            var segment = new Segment(segmentStart, segmentEnd);
            var solution = solver.GetSolution(equaltion, segment, eps);
            Assert.AreEqual(expectedSolution, solution, eps);
        }

        [Test]
        public void FuncX()
        {
            AssertEqualtionHasSolution(x => x, -10, 10, 0, 1e-7);
        }

        [Test]
        public void Func2X()
        {
            AssertEqualtionHasSolution(x => 2 * x, -10, 10, 0, 1e-7);
        }

        [Test]
        public void Func2X2()
        {
            AssertEqualtionHasSolution(x => 2 * x + 2, -10, 10, -1, 1e-7);
        }

        [Test]
        public void FuncSin()
        {
            AssertEqualtionHasSolution(x => Math.Sin(x), -Math.PI / 4, Math.PI / 4, 0, 1e-7);
        }

        [Test]
        public void FuncCos()
        {
            AssertEqualtionHasSolution(x => Math.Cos(x), Math.PI / 4, 3 * Math.PI / 4, Math.PI / 2, 1e-7);
        }

        [Test]
        public void SolutionOnSegmentStart()
        {
            AssertEqualtionHasSolution(x => 2 * x, 0, 10, 0, 1e-7);
        }

        [Test]
        public void SolutionOnSegmentEnd()
        {
            AssertEqualtionHasSolution(x => 2 * x, -10, 0, 0, 1e-7);
        }

        [Test]
        public void NoSolutionOnSegment()
        {
            Assert.Throws<ArgumentException>(()=> solver.GetSolution(x => x, new Segment(2, 3), 1e-7));
        }
    }
}
