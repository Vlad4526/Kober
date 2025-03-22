using System;

class Program
{
    // Функция для вычисления факториала числа
    static double Factorial(int num)
    {
        double result = 1;
        for (int i = 2; i <= num; i++)
        {
            result *= i;
        }
        return result;
    }

    // Функция для приближенного вычисления S(x)
    static double ApproximateS(double x, double tol = 1e-6)
    {
        int n = 0;
        double term = x; // Первый член ряда
        double sumS = term;

        while (Math.Abs(term) >= tol)
        {
            n++;
            double numerator = 1;
            for (int i = 1; i <= 2 * n - 1; i += 2)
            {
                numerator *= i;
            }

            term = Math.Pow(-1, n) * numerator * Math.Pow(x, 2 * n + 1) / (Math.Pow(2, n) * Factorial(n) * (2 * n + 1));
            sumS += term;
        }

        return sumS;
    }

    static void Main()
    {
        // Заданные значения x
        double[] xValues = { 0.5, 0.9, 1.0 };

        // Вывод заголовка таблицы
        Console.WriteLine("x\tS(x)\ty(x)");

        // Перебор всех значений x
        foreach (double x in xValues)
        {
            // Вычисление S(x) с помощью приближенного метода
            double sX = ApproximateS(x);

            // Вычисление y(x) с помощью стандартной функции
            double yX = Math.Log(x + Math.Sqrt(1 + x * x));

            // Вывод результатов
            Console.WriteLine($"{x:F1}\t{sX:F6}\t{yX:F6}");
        }
    }
}
