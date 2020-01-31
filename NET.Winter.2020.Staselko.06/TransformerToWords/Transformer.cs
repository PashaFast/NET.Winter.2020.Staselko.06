using System.Collections.Generic;
using System.Text;

namespace TransformerToWords
{
    /// <summary>
    /// Class Transformer.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Converts any double number (System.Double) to its "word format".
        /// </summary>
        /// <param name="number">Input double number.</param>
        /// <returns> "Word format" of input number.</returns>
        public string TransformToWords(double number)
        {
            if (double.IsNaN(number))
            {
                return "Not a number";
            }

            if (number == double.Epsilon)
            {
                return "Epsilon";
            }

            if (double.IsNegativeInfinity(number))
            {
                return "Negative infinity";
            }

            if (double.IsPositiveInfinity(number))
            {
                return "Positive infinity";
            }

            if (number == 0)
            {
                return "zero";
            }

            StringBuilder sb = new StringBuilder();

            string stringNumber = number.ToString();
            Dictionary<char, string> englishWordFormat = new Dictionary<char, string>
            {
                { '-', "minus" },
                { '.', "point" },
                { '0', "zero" },
                { '1', "one" },
                { '2', "two" },
                { '3', "three" },
                { '4', "four" },
                { '5', "five" },
                { '6', "six" },
                { '7', "seven" },
                { '8', "eight" },
                { '9', "nine" },
                { 'E', "E" },
                { '+', "plus" },
            };

            for (int i = 0; i < stringNumber.Length; i++)
            {
                sb.Append(englishWordFormat[stringNumber[i]]);
                if (i < stringNumber.Length - 1)
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }
    }
}
