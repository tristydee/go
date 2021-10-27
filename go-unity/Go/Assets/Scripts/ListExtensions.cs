using System.Collections.Generic;

namespace Common
{
    public static class ListExtensions
    {
        //todo: add shuffle extension and use in random move selector
        /// <summary>Creates a fully random permutation.</summary>
        public static void Shuffle<T>(this IList<T> list, System.Random random)
        {
            //Fisher-Yates Algorithm
            var n = list.Count;
            for (var i = 0; i < n - 1; i++)
            {
                var j = random.Next(i, n);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}