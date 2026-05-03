using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                double[] data = { 115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110 };
                int n = data.Length;


                Array.Sort(data);


                double sum = 0;
                foreach (double x in data) sum += x;
                double mean = sum / n;

                double mode = data[0];
                int maxCount = 0;
                for (int i = 0; i < n; i++)
                {
                    int count = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (data[j] == data[i]) count++;
                    }
                    if (count > maxCount) { maxCount = count; mode = data[i]; }
                }


                double median = data[n / 2];

                double sumSqDiff = 0;
                double sumDeviations = 0;
                foreach (double x in data)
                {
                    sumSqDiff += Math.Pow(x - mean, 2);
                    sumDeviations += (x - mean);
                }
                double variance = sumSqDiff / n;
                double stdDev = Math.Sqrt(variance);


                double p20 = data[(int)(0.20 * n)];
                double q1 = data[n / 4];
                double q3 = data[3 * n / 4];
                double iqr = q3 - q1;


                double range = data[n - 1] - data[0];


                Console.WriteLine("Mean: " + mean);
                Console.WriteLine("Mode: " + mode);
                Console.WriteLine("Median/P50/Q2: " + median);
                Console.WriteLine("P20: " + p20);
                Console.WriteLine("Q3: " + q3);
                Console.WriteLine("Range: " + range);
                Console.WriteLine("Standard Deviation: " + stdDev);
                Console.WriteLine("IQR: " + iqr);
                Console.WriteLine("Sum of Deviations: " + Math.Round(sumDeviations, 2));




                Console.WriteLine("\n--- Outliers Check ---");
                double lowerBound = q1 - 1.5 * iqr;
                double upperBound = q3 + 1.5 * iqr;

                for (int i = 0; i < n; i++)
                {
                    if (data[i] < lowerBound || data[i] > upperBound)
                    {
                        Console.WriteLine(data[i] + " is an Outlier!");
                    }
                }
            }
        }
    }
}

