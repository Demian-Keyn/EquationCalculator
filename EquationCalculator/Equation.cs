using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EquationCalculator
{
    
    public static class Equation
    {

        public static Tuple<double,double> QuadraticEquation(double a, double b, double c) {

            if(a == 0) {
                throw new ArgumentException("\"a\" не может равняться нулю");
            }

            double x1 = 0, x2 = 0;

            var discriminant = Math.Pow(b, 2) - 4 * a * c;

            if(discriminant < 0) {
                return null;
            } 
            else if (discriminant == 0) {
                x1 = -b / (2 * a);
                x2 = x1;
            } 
            else {
                x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            }
            return Tuple.Create(x1, x2);
        }

    }
}
