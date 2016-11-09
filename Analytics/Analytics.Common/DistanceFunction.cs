using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Analytics.Common
{
    public static class DistanceFunction
    {
        public static double Minkowski(double[] xs, double[] ys, double p)
        {
            var sum = 0.0;
            for (var i = 0; i < xs.Count(); i++)
            {
                var diff = Math.Abs(xs[i] - ys[i]);
                sum += Math.Pow(diff, p);
            }
            return Math.Pow(sum, 1.0 / p);
        }

        public static double Manhatten(double[] xs, double[] ys)
        {
            return Minkowski(xs, ys, 1);
        }

        public static double Euclidean(double[] xs, double[] ys)
        {
            return Minkowski(xs, ys, 2);
        }

        public static double Hamming(double[] xs, double[] ys, double tolerance = 0)
        {
            var sum = 0.0;
            for (var i = 0; i < xs.Count(); i++)
            {
                sum += Math.Abs(xs[i] - ys[i]) > tolerance ? 1 : 0;
            }
            return sum;
        }

        public static double ManhattenFast(double[] xs, double[] ys)
        {
            var total = 0.0;
            var count = xs.Count();
            for (var i = 0; i < count; i++)
            {
                total += Math.Abs(xs[i] - ys[i]);
            }
            return total;
        }

        public static double EuclideanFast(double[] xs, double[] ys)
        {
            var total = 0.0;
            var count = xs.Count();
            for (var i = 0; i < count; i++)
            {
                var sum = xs[i] - ys[i];
                total += sum * sum;
            }
            return Math.Sqrt(total);
        }

    }
}
