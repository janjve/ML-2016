using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Analytics.Common;
using Analytics.MachineLearning.Classifiers;
using Analytics.Tests.Helpers;
using Shouldly;

namespace Analytics.Tests.MachineLearningTests
{
    [TestClass]
    public class ClassifierTests
    {

        [TestMethod]
        public void KNearestNeighborsIrisTest()
        {
            IrisClassifierTest(new KNearestNeighbors(10));
        }

        [TestMethod]
        public void DecisionTreeIrisTest()
        {
            IrisClassifierTest(new DecisionTree());
        }

        private static void IrisClassifierTest(IClassifier classifier)
        {
            var data = TestDataset.Iris();
            data.Shuffle(new Random(1));
            var split = (int)(data.Count * 0.8);
            var trainingSet = data.Take(split).ToList();
            var validationSet = data.Skip(split)
                .Select(x => new Tuple<double[], double>(x.Take(x.Length - 1).ToArray(), x.Last()))
                .ToList();

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
