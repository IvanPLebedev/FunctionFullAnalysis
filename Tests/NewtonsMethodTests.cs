using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FunctionFullAnalysis.Solver.SolversMethods;
using FunctionFullAnalysis.Differentiators;

namespace FunctionFullAnalysis.Tests
{
    [TestFixture]
    class NewtonsMethodTests
    {
        private readonly ISolverMethodOnSegment solver = new NewtonsMethod(new Differentiator());
        private void AssertEqualtionHasSolution(Expression<Func<double, double>> equaltion, double segmentStart, double segmentEnd, double expectedSolution, double eps)
        {
            var solution = solver.GetSolution(equaltion, segmentStart, segmentEnd, eps);
            Assert.AreEqual(expectedSolution, solution, eps);
        }

        [Test]
        public void DifferentiateConstant()
        {
            AssertEqualtionHasSolution(x => x, -10, 10, 0, 1e-7);
        }
    }
}
