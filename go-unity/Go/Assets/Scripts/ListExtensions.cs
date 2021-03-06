using System.Collections.Generic;

namespace Common
{
    public static class ListExtensions
    {
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

        public static void AddDistinct<T>(this IList<T> list, T item)
        {
            if (!list.Contains(item))
                list.Add(item);
        }
    }
}