using System;
using System.Collections.Generic;

namespace FilterArrayByKeyWithPartial
{
    public static partial class ArrayExtension
    {
        public static int[] FilterArrayByKey(int[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "cannot be null!");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("cannot be empty!", nameof(source));
            }

            List<int> result = new List<int>();

            foreach (var t in source)
            {
                AddToArrayIfMatch(result, t);
            }

            return result.ToArray();
        }

        static partial void AddToArrayIfMatch(List<int> array, int number);
    }
}
