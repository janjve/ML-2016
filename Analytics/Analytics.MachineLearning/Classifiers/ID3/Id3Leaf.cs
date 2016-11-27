using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.MachineLearning.Classifiers.ID3
{
    public class Id3Leaf : Id3Node
    {
        public double Label { get; set; }
    }
}
