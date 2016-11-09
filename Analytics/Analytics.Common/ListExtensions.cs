using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Common
{
    public static class ListExtensions
    {
        public static IEnumerable<LinkedListNode<T>> Nodes<T>(this LinkedList<T> list)
        {
            for (var node = list.First; node != null; node = node.Next)
            {
                yield return node;
            }
        }

        public static IEnumerable<LinkedListNode<T>> NodesReversed<T>(this LinkedList<T> list)
        {
            for (var node = list.Last; node != null; node = node.Previous)
            {
                yield return node;
            }
        }

        public static void AddWhere<T>(this LinkedList<T> list, T value, Predicate<T> predicate)
        {
            var node = list.Nodes().FirstOrDefault(x => predicate(x.Value));
            if (node != null)
            {
                list.AddBefore(node, value);
            }
            else
            {
                list.AddLast(value);
            }
        }

        public static void AddWhereReversed<T>(this LinkedList<T> list, T value, Predicate<T> predicate)
        {
            var node = list.NodesReversed().FirstOrDefault(x => predicate(x.Value));
            if (node != null)
            {
                list.AddBefore(node, value);
            }
            else
            {
                list.AddFirst(value);
            }
        }

        public static void Shuffle<T>(this IList<T> list, Random rng)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}
