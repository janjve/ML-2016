using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.MachineLearning.Classifiers
{
    public class DecisionTree : IClassifier
    {
        private readonly IList<double[]> _trainingSet;

        public DecisionTree()
        {

        }

        public void Train(IList<double[]> trainingSet)
        {
            throw new NotImplementedException();
        }

        public double Predict(double[] record)
        {
            throw new NotImplementedException();
        }
    }
}
