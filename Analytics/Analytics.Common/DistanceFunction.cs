using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Analytics.Common
{
    public static class DistanceFunction
    {
        public static double ManhattenFast(int[] xs, int[] ys)
        {
            var total = 0;
            var count = xs.Count();
            for (var i = 0; i < count; i++)
            {
                total += Math.Abs(xs[i] - ys[i]);
            }
            return total;
        }

        public static double EuclideanFast(int[] xs, int[] ys)
        {
            var total = 0;
            var count = xs.Count();
            for (var i = 0; i < count; i++)
            {
                var sum = xs[i] - ys[i];
                total += sum * sum;
            }
            return Math.Sqrt(total);
        }

        public static double Minkowski(int[] xs, int[] ys, int p)
        {
            var sum = 0.0;
            for (var i = 0; i < xs.Count(); i++)
            {
                var diff = Math.Abs(xs[i] - ys[i]);
                sum += Math.Pow(diff, p);
            }
            return Math.Pow(sum, 1.0 / p);
        }

        public static double Euclidean(int[] xs, int[] ys)
        {
            return Minkowski(xs, ys, 2);
        }

        public static double Manhatten(int[] xs, int[] ys)
        {
            return Minkowski(xs, ys, 1);
        }

    }
}
