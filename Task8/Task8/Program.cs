using System;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите начало отрезка по оси x: ");
            string begin = Console.ReadLine();
            Console.Write("Введите конец отрезка по оси x: ");
            string end = Console.ReadLine();
            Console.Write("Введите точность вычислений: ");
            string epsilon = Console.ReadLine();

            if (!double.TryParse(begin, out double parsedBegin) || !double.TryParse(end, out double parsedEnd) || !double.TryParse(epsilon, out double parsedEpsilon))
            {
                Console.WriteLine("Ошибка при вводе значений.");
                Console.ReadKey(true);
                return;
            }

            if (function(parsedBegin) * function(parsedEnd) >= 0)
            {
                Console.WriteLine("Ошибка.");
                Console.ReadKey(true);
                return;
            }
            double midSegment = (parsedBegin + parsedEnd) / 2;

            if (function(midSegment) == 0)
            {
                Console.WriteLine($"Корень: {midSegment}");
                Console.ReadKey(true);
                return;
            }

            while (Math.Abs(parsedBegin) - Math.Abs(parsedEnd) > parsedEpsilon)
            {
                if (function(parsedBegin) * function(midSegment) < 0)
                {
                    parsedEnd = midSegment;                    
                }
                if (function(parsedEnd) * function(midSegment) < 0)
                {
                    parsedBegin = midSegment;
                }
                midSegment = (parsedBegin + parsedEnd) / 2;
            }
            Console.WriteLine($"Корень с точностью {parsedEpsilon}: {midSegment}");
        }

        static double function(double x)
        {
            return Math.Pow(x, 3) - 6 * x + 2;
        }
    }
}
