using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Analytics.Common;
using Analytics.MachineLearning.Classifiers;
using Shouldly;

namespace Analytics.Tests.MachineLearningTests
{
    [TestClass]
    public class KNearestNeighborsTests
    {
        private List<double[]> LoadIris()
        {
            // Quick and dirty.
            var data = new List<double[]>();
            var lines = File.ReadAllLines(@"Data\iris.data.txt");
            var irisMap = new Dictionary<string, string> { { "Iris-setosa", "0.0" }, { "Iris-versicolor", "1.0" }, { "Iris-virginica", "2.0" } };

            foreach (var record in lines.Select(line => line.Split(',')))
            {
                record[record.Length - 1] = irisMap[record[record.Length - 1]];
                data.Add(record.Select(double.Parse).ToArray());
            }
            return data;
        }

        [TestMethod]
        public void KNearestNeighborsIrisTest()
        {
            var data = LoadIris();
            data.Shuffle(new Random(1));
            var split = (int)(data.Count * 0.8);
            var trainingSet = data.Take(split).ToList();
            var validationSet = data.Skip(split)
                .Select(x => new Tuple<double[], double>(x.Take(x.Length - 1).ToArray(), x.Last()))
                .ToList();

            var classifier = new KNearestNeighbors(10);
            classifier.Train(trainingSet);

            var correctlyPredicted = 0;
            var incorrectlyPredicted = 0;

            validationSet.ForEach(x =>
            {
                if (Math.Abs(classifier.Predict(x.Item1) - x.Item2) < 0.00001)
                    correctlyPredicted++;
                else incorrectlyPredicted++;

            });

            var percentCorrect = ((correctlyPredicted + 0.0) / (correctlyPredicted + incorrectlyPredicted));

            percentCorrect.ShouldBeGreaterThanOrEqualTo(0.90);

        }
    }
}
