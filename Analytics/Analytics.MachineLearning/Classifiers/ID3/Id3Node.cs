using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.MachineLearning.Classifiers.ID3
{
    public class Id3Node
    {
        public List<Id3Node> Children { get; set; }

        public Id3Node()
        {
            Children = new List<Id3Node>();
        }

    }
}
