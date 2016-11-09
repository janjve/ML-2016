using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.MachineLearning.Classifiers
{
    public interface IClassifier
    {
        void Train(IList<double[]> trainingSet);
        double Predict(double[] record);
    }
}
