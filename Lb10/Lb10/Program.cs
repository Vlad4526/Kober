using System;

class Program
{
    static void Main()
    {
        // Приклад масиву платежів
        Платіж[] платежі = new Платіж[]
        {
            new Платіж("UA111111", "UA222222", new DateTime(2025, 4, 5), 500),
            new Платіж("UA333333", "UA444444", new DateTime(2025, 5, 10), 1200),
            new Платіж("UA555555", "UA666666", new DateTime(2025, 5, 18), 800),
            new Платіж("UA777777", "UA888888", new DateTime(2025, 6, 2), 2000),
            new Платіж("UA999999", "UA000000", new DateTime(2025, 6, 25), 300)
        };

        // Запитуємо початкову дату
        Console.Write("Введіть початкову дату (у форматі dd.MM.yyyy): ");
        DateTime початок = DateTime.Parse(Console.ReadLine());

        // Запитуємо кінцеву дату
        Console.Write("Введіть кінцеву дату (у форматі dd.MM.yyyy): ");
        DateTime кінець = DateTime.Parse(Console.ReadLine());

        // Запитуємо мінімальну суму
        Console.Write("Введіть мінімальну суму платежу: ");
        decimal мінСума = decimal.Parse(Console.ReadLine());

        // Виводимо результат
        Console.WriteLine($"\nПлатежі з періоду {початок:dd.MM.yyyy} — {кінець:dd.MM.yyyy}, де сума ≥ {мінСума}:");
        foreach (var платіж in платежі)
        {
            if (платіж.Дата >= початок && платіж.Дата <= кінець && платіж.Сума >= мінСума)
            {
                Console.WriteLine($"Платник: {платіж.РахунокПлатника}");
                Console.WriteLine($"Отримувач: {платіж.РахунокОтримувача}");
                Console.WriteLine($"Дата: {платіж.Дата:dd.MM.yyyy}");
                Console.WriteLine($"Сума: {платіж.Сума} грн");
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
