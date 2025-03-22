using System;

class Program
{
    static void Main()
    {
        // Запросим у пользователя ввести значения x и y
        Console.Write("Введите значение x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите значение y: ");
        double y = Convert.ToDouble(Console.ReadLine());

        // Шаг 1: Вычислим числитель (верхнюю часть дроби)
        double numerator = 2 * Math.Cos(x - Math.PI / 2); // 2 * косинус(x - π/2)

        // Шаг 2: Вычислим знаменатель (нижнюю часть дроби)
        double denominator = 0.5 + Math.Pow(Math.Sin(y), 2); // 0.5 + синус(y) в квадрате

        // Шаг 3: Вычислим значение дроби
        double fraction = numerator / denominator; // Числитель деленный на знаменатель

        // Шаг 4: Вычислим значение степени
        double power = Math.Pow(x / y, 3); // (x / y) в кубе

        // Шаг 5: Сложим результаты дроби и степени
        double result = fraction + power;

        // Выведем результат на экран
        Console.WriteLine($"Результат вычисления: {result}");
    }
}

