using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.MachineLearning.Classifiers.ID3
{
    public class Id3Branch : Id3Node
    {
        public List<Id3Node> Children { get; set; }
        public List<double[]> Data { get; set; }

        public Id3Branch()
        {
            Children = new List<Id3Node>();
        }

        public List<Id3Node> Split()
        {
            return null;
        }

        public Id3Leaf MakeLeaf(double label)
        {
            return new Id3Leaf { Label = label };
        }

    }
}
