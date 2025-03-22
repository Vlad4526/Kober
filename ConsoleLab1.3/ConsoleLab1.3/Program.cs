using System;

class Program
{
    static void Main()
    {
        // вопросы
        string[] questions = {
            "Профессор лег спать в 8 часов, а встал в 9 часов. Сколько часов проспал профессор?",
            "На двух руках десять пальцев. Сколько пальцев на 10?",
            "Сколько цифр в дюжине?",
            "Сколько нужно сделать распилов, чтобы распилить колоду на 12 частей?",
            "Врач сделал три укола в интервале 30 минут. Сколько времени он затратил?",
            "Сколько цифр 9 в интервале 1100?",
            "Пастух имел 30 овец. Все, кроме одной, разбежались. Сколько овец осталось?"
        };

        // Ответы
        int[] correctAnswers = { 1, 50, 2, 11, 30, 1, 1 };

        // Переменная для подсчета правильных ответов
        int score = 0;

        // Цикл для прохода по всем вопросам
        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine(questions[i]); // Выводим вопрос
            Console.Write("Ваш ответ: ");
            int userAnswer;
            bool isValidInput = int.TryParse(Console.ReadLine(), out userAnswer); // Пытаемся преобразовать ввод в число

            if (isValidInput && userAnswer == correctAnswers[i])
            {
                score++; // Если ответ правильный, увеличиваем счетчик
            }
            else if (!isValidInput)
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            }
        }

        // Оцениваем результаты
        switch (score)
        {
            case 7:
                Console.WriteLine("Гений!");
                break;
            case 6:
                Console.WriteLine("Эрудит!");
                break;
            case 5:
                Console.WriteLine("Нормальный!");
                break;
            case 4:
                Console.WriteLine("Здібності середні!");
                break;
            case 3:
                Console.WriteLine("Здібності нижче середнього!");
                break;
            default:
                Console.WriteLine("Вам треба відпочити!");
                break;
        }
    }
}
