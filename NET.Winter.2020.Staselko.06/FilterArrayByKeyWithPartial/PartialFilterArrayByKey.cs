using System;
using System.Collections.Generic;

namespace FilterArrayByKeyWithPartial
{
    public static partial class ArrayExtension
    {
        private static int digit;
        public static int Digit 
        {
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException("digit must be >=0 and <=9");
                }
                else
                {
                    digit = value;
                }
            }

            get
            {
                return digit;
            }
        }

        static partial void AddToArrayIfMatch(List<int> array, int number)
        {
            if (IsDigitPresent(number))
            {
                array.Add(number);
            }
        }

        private static bool IsDigitPresent(int number)
        {
            
            while (number / 10 != 0)
            {
                if (Math.Abs(number % 10) == Digit)
                {
                    return true;
                }

                number /= 10;
            }

            return Math.Abs(number % 10) == Digit;
        }
    }
}
