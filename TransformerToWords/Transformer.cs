using System;
using System.Globalization;
using System.Text;

namespace TransformerToWords
{
    /// <summary>
    /// Implements transformer class.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Transforms each element of source array into its 'word format'.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of 'word format' of elements of source array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <example>
        /// new[] { 2.345, -0.0d, 0.0d, 0.1d } => { "Two point three four five", "Minus zero", "Zero", "Zero point one" }.
        /// </example>
        ///
        public static string TransformString(double source)
        {
            if (double.IsNaN(source))
            {
                return "Not a Number";
            }

            if (source == double.PositiveInfinity)
            {
                return "Positive Infinity";
            }

            if (source == double.NegativeInfinity)
            {
                return "Negative Infinity";
            }

            if (source == double.Epsilon)
            {
                return "Double Epsilon";
            }

            string number = source.ToString(CultureInfo.CurrentCulture);
            StringBuilder sb = new StringBuilder();

            foreach (char num in number)
            {
                switch (num)
                {
                    case '1': sb.Append("one ");
                              break;
                    case '2':
                              sb.Append("two ");
                              break;
                    case '3':
                              sb.Append("three ");
                              break;
                    case '4':
                              sb.Append("four ");
                              break;
                    case '5':
                              sb.Append("five ");
                              break;
                    case '6':
                              sb.Append("six ");
                              break;
                    case '7':
                              sb.Append("seven ");
                              break;
                    case '8':
                              sb.Append("eight ");
                              break;
                    case '9':
                              sb.Append("nine ");
                              break;
                    case '0':
                              sb.Append("zero ");
                              break;
                    case '-':
                              sb.Append("minus ");
                              break;
                    case 'E':
                              sb.Append("E ");
                              break;
                    case '+':
                              sb.Append("plus ");
                              break;
                    case '.':
                              sb.Append("point ");
                              break;
                }
            }

            sb.Remove(sb.Length - 1, 1);
            sb[0] = (char)(sb[0] - 32);
            return sb.ToString();
        }

        public string[] Transform(double[]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Array cannot be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            string[] result = new string[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = TransformString(source[i]);
            }

            return result;
        }
    }
}
