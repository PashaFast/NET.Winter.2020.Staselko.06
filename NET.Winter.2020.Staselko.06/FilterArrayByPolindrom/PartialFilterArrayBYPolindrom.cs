using System;
using System.Collections.Generic;
using System.Text;

namespace FilterArrayByPolindrom
{
        public static partial class ArrayExtension
        {
            static partial void AddToArrayIfMatch(List<int> array, int number)
            {
                if (IsPalindrome(number))
                {
                    array.Add(number);
                }
            }

            private static bool IsPalindrome(int number)
            {
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(number), "cannot be negative");
                }

                int temp = Reverse(number, 0);

                if (temp == number)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private static int Reverse(int n, int temp)
            {
                if (n == 0)
                {
                    return temp;
                }

                temp = (temp * 10) + (n % 10);

                return Reverse(n / 10, temp);
            }
        }
    }


