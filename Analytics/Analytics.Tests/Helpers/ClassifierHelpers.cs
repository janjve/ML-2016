using Analytics.Common;
using Analytics.MachineLearning.Classifiers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Tests.Helpers
{
    public static class ClassifierHelpers
    {
        public static void IrisClassifierTest(IClassifier classifier)
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
