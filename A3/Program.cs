
// C# Style Guide Rules Applied:
// - DO use Pascal Casing for class names and method names.
// - DO use camelCasing for variables and parameters.
// - DO use XML documentation comments for providing information about methods.
// - DO place opening braces on the same line as the method or control structure.
// - DO use consistent indentation (4 spaces per level).
// - DO use spaces around binary operators for clarity.
// - DO use blank lines to separate logical sections of code.
// - DO use braces for control structures even for single statements.
// - DO throw exceptions with informative messages.
// - DO keep the Main method clean with minimal code and clear separation of concerns.
using System;
using System.Collections.Generic;

namespace Assignment3
{
    /// <summary>
    /// Library of statistical functions using Generics for different statistical calculatuions
    /// see http://www.calculator.net/standard-deviation-calculator.html for sample standard deviation calculations
    ///  
    /// @author Enodie Programmer
    /// </summary>

    public class A3
    {
        /// <summary>
        /// Calculates the average of a list of doubles.
        /// </summary>
        /// <param name="x">The list of doubles.</param>
        /// <param name="includenegative">Include negative values in the calculation.</param>
        /// <returns>The average of the list.</returns>
        public static double Average(List<double> x, bool includenegative)
        {
            double sum = Sum(x, includenegative);
            int count = 0;

            for (int i = 0; i < x.Count; i++)
            {
                if (includenegative || x[i] >= 0)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                throw new ArgumentException("x contains no values greater than or equal to 0");
            }

            return sum / count;
        }

        /// <summary>
        /// Calculates the sum of a list of doubles.
        /// </summary>
        /// <param name="data">The list of doubles.</param>
        /// <param name="includenegative">Include negative values in the sum.</param>
        /// <returns>The sum of the list.</returns>
        public static double Sum(List<double> data, bool includenegative)
        {
            if (data.Count == 0)
            {
                throw new ArgumentException("data cannot be empty");
            }

            double sum = 0.0;

            foreach (double val in data)
            {
                if (includenegative || val >= 0)
                {
                    sum += val;
                }
            }

            return sum;
        }

        /// <summary>
        /// Calculates the median of a list of doubles.
        /// </summary>
        /// <param name="data">The list of doubles.</param>
        /// <returns>The median of the list.</returns>
        /// 
        public static double Median(List<double> data)
        {
            if (data.Count == 0)
            {
                throw new ArgumentException("data cannot be empty");
            }

            data.Sort();

            double Median = data[data.Count / 2];
            if (data.Count % 2 == 0)
                Median = (data[data.Count / 2] + data[data.Count / 2 - 1]) / 2;

            return Median;
        }

        /// <summary>
        /// Calculates the sample standard deviation of a list of doubles.
        /// </summary>
        /// <param name="data">The list of doubles.</param>
        /// <returns>The sample standard deviation of the list.</returns>
        public static double Stdev(List<double> data)
        {
            if (data.Count <= 1)
            {
                throw new ArgumentException("data cannot be empty");
            }

            int n = data.Count;
            double sum = 0;
            double average = Average(data, true);

            for (int i = 0; i < n; i++)
            {
                double value = data[i];
                sum += Math.Pow(value - average, 2);
            }

            double stdev = Math.Sqrt(sum / (n - 1));
            return stdev;
        }


        /// <summary>
        /// Main entry point for the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Sample Output for Statistical Functions Library");
            List<double> testData = new List<double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };
            Console.WriteLine("The sum of the array = {0}", Sum(testData, true));
            Console.WriteLine("The average of the array = {0}", Average(testData, true));
            Console.WriteLine("The median value of the Double data set = {0}", Median(testData));
            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", Stdev(testData));
            Console.WriteLine("Press enter key to exit...");
            Console.ReadLine();
        }
    }
}
