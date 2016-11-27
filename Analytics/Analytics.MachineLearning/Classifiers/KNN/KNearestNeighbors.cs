using System;
using System.Collections.Generic;
using System.Linq;
using Analytics.Common;
using static Analytics.Common.DistanceFunction;

namespace Analytics.MachineLearning.Classifiers.KNN
{
    public class KNearestNeighbors : IClassifier
    {
        private IList<double[]> _trainingSet;
        private readonly int _k;

        public KNearestNeighbors(int k)
        {
            _k = k;
        }

        // Lazy, supervised learner.
        public void Train(IList<double[]> trainingSet)
        {
            _trainingSet = trainingSet;
        }

        public double Predict(double[] record)
        {
            CheckState(record);
            var outputIndex = _trainingSet.First().Count()-1;
            var kNeighbors = new LinkedList<Tuple<double, double>>();
            foreach (var tRecord in _trainingSet)
            {
                var distance = Euclidean(record, tRecord);
                if (kNeighbors.Count < _k)
                {
                    var tuple = Tuple.Create(distance, tRecord[outputIndex]);
                    kNeighbors.AddWhere(tuple, x => x.Item1 > distance);
                }

                else if (kNeighbors.Last().Item1 > distance)
                {
                    kNeighbors.RemoveLast();
                    var tuple = Tuple.Create(distance, tRecord[outputIndex]);
                    kNeighbors.AddWhereReversed(tuple, x => x.Item1 > distance);
                }
            }

            return kNeighbors
                .GroupBy(x => x.Item2)
                .OrderByDescending(x => x.Count())
                .First()
                .Select(x => x.Item2)
                .First();
        }

        private void CheckState(double[] record)
        {
            if (_trainingSet == null || !_trainingSet.Any()) throw new InvalidOperationException("No training set was provided.");
            if (record == null || record.Count() != _trainingSet.First().Count() - 1) throw new InvalidOperationException("Record has invalid number of features.");
        }
    }
}
