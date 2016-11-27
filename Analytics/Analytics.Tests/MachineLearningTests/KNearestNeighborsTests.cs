using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analytics.MachineLearning.Classifiers;
using Analytics.MachineLearning.Classifiers.KNN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Analytics.Tests.Helpers.ClassifierHelpers;

namespace Analytics.Tests.MachineLearningTests
{
    [TestClass]

    public class KNearestNeighborsTests
    {
        [TestMethod]
        public void KNearestNeighborsIrisTest()
        {
            IrisClassifierTest(new KNearestNeighbors(10));
        }
    }
}
