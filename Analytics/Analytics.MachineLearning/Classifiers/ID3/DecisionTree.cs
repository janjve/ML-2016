using System;
using System.Collections.Generic;
using System.Linq;

namespace Analytics.MachineLearning.Classifiers.ID3
{
    public class DecisionTree : IClassifier
    {
        private readonly IList<double[]> _trainingSet;
        private readonly Id3Node _root;

        public DecisionTree()
        {
            _root = new Id3Node();
        }

        public void Train(IList<double[]> trainingSet)
        {
            var attributeCount = trainingSet.First().Count() - 1;
            var attributes = Enumerable.Range(0, attributeCount);

        }

        public double Predict(double[] record)
        {
            throw new NotImplementedException();
        }

        private static void BuildTree(IList<double[]> examples, IEnumerable<int> attributeIndices, List<double[]> parent_examples)
        {
            throw new NotImplementedException();
        }

        private static int MaxInformationGain(IList<double[]> set)
        {
            return 0;
        }
    }
}
