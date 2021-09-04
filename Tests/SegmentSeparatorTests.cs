using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NUnit.Framework;
using FunctionFullAnalysis.Solver;
using FunctionFullAnalysis.Utils;

namespace FunctionFullAnalysis.Tests
{
    [TestFixture]
    class SegmentSeparatorTests
    {
        private readonly ISegmentSeparator separator = new SegmentSeparatorWithSolution();

        private void AssertFindAllSegmentsWithSolution(Expression<Func<double, double>> equaltion, Segment domain, List<double> solutions)
        {
            var rnd = new Random();
            var step = rnd.NextDouble();
            foreach(var segment in separator.GetSegmentsWithSolution(equaltion, domain, step))
            {
                var solutionsCount = solutions.Count;
                foreach(var solution in solutions)
                {
                    if (solution >= segment.A && solution <= segment.B) 
                    {
                        solutions.Remove(solution);
                        break; 
                    }
                }
                Assert.IsTrue(solutionsCount > solutions.Count, $"Segment {segment.A} - {segment.B} dont contain solution");
            }
            Assert.IsTrue(solutions.Count == 0, $"Not all segments were found : {solutions}");
        }

        [Test]
        public void FuncX()
        {
            AssertFindAllSegmentsWithSolution(x => x, new Segment(-3, 3), new List<double>() {0});
        }

        [Test]
        public void DontHaveSolutions1()
        {
            AssertFindAllSegmentsWithSolution(x => 4, new Segment(-3, 3), new List<double>() {});
        }

        [Test]
        public void DontHaveSolutions2()
        {
            AssertFindAllSegmentsWithSolution(x => x * x + 3, new Segment(-3, 3), new List<double>() { });
        }

        [Test]
        public void FuncX2()
        {
            AssertFindAllSegmentsWithSolution(x => x * x - 4, new Segment(-3, 3), new List<double>() { -2, 2 });
        }

        [Test]
        public void Func()
        {
            AssertFindAllSegmentsWithSolution(x => x * x - 1, new Segment(-3, 3), new List<double>() { -1, 1 });
        }
    }
}
