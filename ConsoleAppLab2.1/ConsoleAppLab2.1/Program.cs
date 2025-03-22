using System;

class Program
{
    static void Main()
    {
        // Заданные значения параметра a
        double[] aValues = { 0.5, 1.0, 1.5, 2.0 };

        // Заданные значения аргумента x
        double xStart = 0.0;
        double xEnd = 0.8;
        double dx = 0.5;

        // Перебираем все значения параметра a
        foreach (double a in aValues)
        {
            Console.WriteLine($"Для a = {a}:");

            // Обходим все значения x от xStart до xEnd с шагом dx
            for (double x = xStart; x <= xEnd; x += dx)
            {
                // Проверка на корректность выражения (избегаем деления на ноль)
                if (x - 1 == 0)
                {
                    Console.WriteLine($"  x = {x}: невозможно обчислить (деление на ноль)");
                    continue;
                }

                // Вычисляем y(x)
                double y = Math.Pow(x + 4 * a, (a * x) / (x - 1));

                // Выводим результат
                Console.WriteLine($"  x = {x}, y = {y}");
            }

            // Пустая строка для разделения результатов для разных значений a
            Console.WriteLine();
        }
    }
}