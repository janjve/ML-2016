using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analytics.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Analytics.Tests.Common
{
    [TestClass]
    public class DistanceFunctionTests
    {
        [TestMethod]
        public void EuclideanTest1()
        {
            var xs = new[] { 2, -2 };
            var ys = new[] { -1, 2 };
            DistanceFunction.Euclidean(xs, ys).ShouldBe(5);
            DistanceFunction.EuclideanFast(xs, ys).ShouldBe(5);
        }

        [TestMethod]
        public void EuclideanTest2()
        {
            var xs = new[] { 6, 5, 4, 3, 0, 2, 1, 0 };
            var ys = new[] { 0, 0, 0, 0, -3, 0, 0, 0 };
            DistanceFunction.Euclidean(xs, ys).ShouldBe(10);
            DistanceFunction.EuclideanFast(xs, ys).ShouldBe(10);
        }

        [TestMethod]
        public void EuclideanTest3()
        {
            var xs = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            DistanceFunction.Euclidean(xs, xs).ShouldBe(0);
            DistanceFunction.EuclideanFast(xs, xs).ShouldBe(0);
        }

        [TestMethod]
        public void EuclideanTest4()
        {
            var xs = Enumerable.Repeat(1, 100).ToArray();
            var ys = Enumerable.Repeat(0, 100).ToArray();
            DistanceFunction.Euclidean(xs, ys).ShouldBe(10);
            DistanceFunction.EuclideanFast(xs, ys).ShouldBe(10);
        }

        [TestMethod]
        public void ManhattenTest1()
        {
            var xs = new[] { 2, -2 };
            var ys = new[] { -1, 2 };
            DistanceFunction.Manhatten(xs, ys).ShouldBe(7);
            DistanceFunction.ManhattenFast(xs, ys).ShouldBe(7);
        }

        [TestMethod]
        public void ManhattenTest2()
        {
            var xs = new[] { 6, 5, 4, 3, 0, 2, 1, 0 };
            var ys = new[] { 0, 0, 0, 0, -3, 0, 0, 0 };
            DistanceFunction.Manhatten(xs, ys).ShouldBe(24);
            DistanceFunction.ManhattenFast(xs, ys).ShouldBe(24);
        }

        [TestMethod]
        public void ManhattenTest3()
        {
            var xs = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            DistanceFunction.Manhatten(xs, xs).ShouldBe(0);
            DistanceFunction.ManhattenFast(xs, xs).ShouldBe(0);
        }

        [TestMethod]
        public void ManhattenTest4()
        {
            var xs = Enumerable.Repeat(1, 100).ToArray();
            var ys = Enumerable.Repeat(0, 100).ToArray();
            DistanceFunction.Manhatten(xs, ys).ShouldBe(100);
            DistanceFunction.ManhattenFast(xs, ys).ShouldBe(100);
        }

        [TestMethod]
        public void MinkowskiTest1()
        {
            var xs = new[] { 0, 3, 4, 5 };
            var ys = new[] { 7, 6, 3, -1 };
            DistanceFunction.Minkowski(xs, ys, 5).ShouldBe(7.568, 0.0001);
        }

        [TestMethod]
        public void MinkowskiTest2()
        {
            var xs = new[] { 1,2,3,4 };
            var ys = new[] { -4, -5, -6, -7 };
            DistanceFunction.Minkowski(xs, ys, 5).ShouldBe(11.91, 0.01);
        }

        [TestMethod]
        public void MinkowskiTest3()
        {
            var xs = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            DistanceFunction.Minkowski(xs, xs, 10).ShouldBe(0);
        }

        [TestMethod]
        public void MinkowskiTest4()
        {
            var xs = Enumerable.Repeat(1, 100).ToArray();
            var ys = Enumerable.Repeat(0, 100).ToArray();
            DistanceFunction.Minkowski(xs, ys, 10).ShouldBe(1.58489, 0.00001);
        }
    }
}
