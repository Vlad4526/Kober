using System;

class Program
{
    static Random random = new Random();

    static void Main()
    {
        Console.WriteLine("Добро пожаловать в игру 'GUESS MY NUMBER'!");
        Console.WriteLine("Выберите уровень сложности:");
        Console.WriteLine("1. Легкий (1-10)");
        Console.WriteLine("2. Сложный (10-100)");

        int level = 0;
        while (level != 1 && level != 2)
        {
            Console.Write("Введите номер уровня (1 или 2): ");
            level = Convert.ToInt32(Console.ReadLine());
            if (level != 1 && level != 2)
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите 1 или 2.");
            }
        }

        int userScore = 0;
        int computerScore = 0;

        if (level == 1)
        {
            userScore = PlayLevel1(ref computerScore);
            if (userScore > 0)
            {
                Console.WriteLine("Вы прошли первый уровень! Переходим ко второму уровню.");
                userScore += PlayLevel2(ref computerScore);
            }
        }
        else
        {
            userScore = PlayLevel2(ref computerScore);
        }

        Console.WriteLine($"Игра завершена!");
        Console.WriteLine($"Ваши очки: {userScore}");
        Console.WriteLine($"Очки компьютера: {computerScore}");
    }

    static int PlayLevel1(ref int computerScore)
    {
        int rounds = 3;
        int totalLives = 5; // 50% от 10
        int userScore = 0;

        for (int round = 1; round <= rounds; round++)
        {
            int lives = totalLives;
            int numberToGuess = random.Next(1, 11);
            bool roundWon = false;

            Console.WriteLine($"\nРаунд {round} (1-10). Жизней: {lives}");

            while (lives > 0)
            {
                Console.Write("Введите ваше число: ");
                int guess = Convert.ToInt32(Console.ReadLine());

                if (guess == numberToGuess)
                {
                    Console.WriteLine("Поздравляем! Вы угадали число!");
                    userScore += lives * 5;
                    roundWon = true;
                    break;
                }
                else
                {
                    lives--;
                    Console.WriteLine($"Неправильно. Осталось жизней: {lives}");

                    if (lives > 0)
                    {
                        Console.Write("Хотите получить подсказку? (да/нет): ");
                        string hintChoice = Console.ReadLine().ToLower();
                        if (hintChoice == "да")
                        {
                            lives--;
                            Console.WriteLine($"Подсказка: Загаданное число {(guess < numberToGuess ? "больше" : "меньше")} вашего.");
                        }
                    }
                }
            }

            if (!roundWon)
            {
                computerScore += totalLives * 5;
                Console.WriteLine("Вы проиграли раунд.");
                return 0; // Прерываем игру, если игрок проиграл раунд
            }

            Console.WriteLine($"Промежуточные очки: {userScore}");
        }

        return userScore;
    }

    static int PlayLevel2(ref int computerScore)
    {
        int rounds = 2;
        int totalLives = 25; // 25% от 100
        int userScore = 0;

        for (int round = 1; round <= rounds; round++)
        {
            int lives = totalLives;
            int numberToGuess = random.Next(10, 101);
            bool roundWon = false;

            Console.WriteLine($"\nРаунд {round} (10-100). Жизней: {lives}");

            while (lives > 0)
            {
                Console.Write("Введите ваше число: ");
                int guess = Convert.ToInt32(Console.ReadLine());

                if (guess == numberToGuess)
                {
                    Console.WriteLine("Поздравляем! Вы угадали число!");
                    userScore += lives * 10;
                    roundWon = true;
                    break;
                }
                else
                {
                    lives--;
                    Console.WriteLine($"Неправильно. Осталось жизней: {lives}");

                    if (lives > 0)
                    {
                        Console.Write("Хотите получить подсказку? (да/нет): ");
                        string hintChoice = Console.ReadLine().ToLower();
                        if (hintChoice == "да")
                        {
                            lives--;
                            Console.WriteLine($"Подсказка: Загаданное число {(guess < numberToGuess ? "больше" : "меньше")} вашего.");
                        }
                    }
                }
            }

            if (!roundWon)
            {
                computerScore += totalLives * 10;
                Console.WriteLine("Вы проиграли раунд.");
                return 0; // Прерываем игру, если игрок проиграл раунд
            }

            Console.WriteLine($"Промежуточные очки: {userScore}");
        }

        return userScore;
    }
}