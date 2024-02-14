using System;

namespace Program
{
    internal abstract class Program
    {
        private delegate double Sum(int number);
        
        public static void Main()
        {
            Sum sum1 = n => 1.0 / Math.Pow(2, n);
            Console.WriteLine($"Результат обчислення ряду 1 + 1/2 + 1/4 + 1/8 + 1/16 + ... : {Calculate(sum1, 0.00001)}");

            Sum sum2 = n => 1.0 / Factorial(n);
            Console.WriteLine($"Результат обчислення ряду 1 + 1/2! + 1/3! + 1/4! + 1/5! + ... : {Calculate(sum2, 0.00001) - 1}");
            
            Sum sum3 = n => Math.Pow(-1, n) * 1.0 / Math.Pow(2, n);
            Console.WriteLine($"Результат обчислення ряду -1 + 1/2 - 1/4 + 1/8 - 1/16 + ... : -{Calculate(sum3, 0.00001)}");
        }
        
        private static double Calculate(Sum data, double precision)
        {
            double sum = 0;

            for (int i = 0; Math.Abs(data(i)) >= precision; i++)
            {
                sum += data(i);
            }

            return sum;
        }
        
        private static double Factorial(int number)
        {
            double factorial = 1;
            
            for (double i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            
            return factorial;
        }
    }
}