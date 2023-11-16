using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquationCalculator;

namespace EquationCalculator.Tests
{
    public class EquationTests
    {
        [Theory]
        [InlineData(1, 4, 3, -1, -3)]
        [InlineData(1, -7, 10, 5, 2)]
        [InlineData(4, -4, 1, 0.5, 0.5)]
        public void QuadraticEquationTests(double a, double b, double c, double x1, double x2)
        {
            Tuple<double, double> result = Equation.QuadraticEquation(a, b, c);
            Tuple<double, double> expected = Tuple.Create(x1, x2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void QuadraticEquationExceptionTests()
        {
            var exception = Record.Exception(() => Equation.QuadraticEquation(0, 1, 1));
            Assert.IsType<ArgumentException>(exception);
        }

        [Fact]
        public void QuadraticEquationSecondExceptionTests()
        {
            var result = Record.Exception(() => Equation.QuadraticEquation(1, 1, 1));
            Assert.Null(result);
        }

    }
}
