using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace Analytics.MachineLearning.Classifiers.ID3
{
    public class DecisionTree : IClassifier
    {
        private readonly IList<double[]> _trainingSet;
        private Id3Node _root;

        public DecisionTree()
        {

        }

        public void Train(IList<double[]> trainingSet)
        {
            var attributeCount = trainingSet.First().Count() - 1;
            var attributes = Enumerable.Range(0, attributeCount);

            _root = Build(new Id3Branch(), attributes, trainingSet);
        }

        public Id3Node Build(Id3Branch branch, IEnumerable<int> attributes, IList<double[]> trainingSet)
        {
            if (branch.Data.Select(x => x.Last()).Distinct().Count() < 2)
            {
                branch.MakeLeaf(branch.Data.First().First());
            }
            else if (!attributes.Any())
            {
                var majority = branch.Data.Select(x => x.Last())
                    .GroupBy(x => x)
                    .OrderByDescending(x => x.Count())
                    .First()
                    .Select(x => x)
                    .First();
                // Handle
            }
            else
            {
                
            }
            return branch;
        }

        public double Predict(double[] record)
        {
            throw new NotImplementedException();
        }

        private static int MaxInformationGain(IList<double[]> set)
        {
            return 0;
        }
    }
}
