using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Analytics.Common;
using Analytics.MachineLearning.Classifiers;
using Analytics.MachineLearning.Classifiers.ID3;
using Analytics.Tests.Helpers;
using Shouldly;

using static Analytics.Tests.Helpers.ClassifierHelpers;

namespace Analytics.Tests.MachineLearningTests
{
    [TestClass]
    public class DecisionTreeTests
    {
        [TestMethod]
        public void DecisionTreeIrisTest()
        {
            IrisClassifierTest(new DecisionTree());
        }
    }
}
