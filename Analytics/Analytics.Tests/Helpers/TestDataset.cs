using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Analytics.Tests.Helpers
{
    public static class TestDataset
    {
        public static List<double[]> Iris()
        {
            var data = new List<double[]>();
            var lines = File.ReadAllLines(@"Data\iris.data.txt");
            var irisMap = new Dictionary<string, string> { { "Iris-setosa", "0.0" }, { "Iris-versicolor", "1.0" }, { "Iris-virginica", "2.0" } };

            foreach (var record in lines.Select(line => line.Split(',')))
            {
                record[record.Length - 1] = irisMap[record[record.Length - 1]];
                data.Add(record.Select(double.Parse).ToArray());
            }
            return data;
        }
    }
}
