﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FunctionFullAnalysis.Differential
{
    public class Differentiator
    {
        private readonly DifferentialVisitor visitor;

        public Differentiator()
        {
            visitor = new DifferentialVisitor();
        }

        public Expression<Func<double, double>> Run(Expression<Func<double, double>> function)
        {
            return visitor.GetDerivative(function);
        }
    }
}