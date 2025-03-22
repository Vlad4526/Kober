using System;

class Program
{
    static void Main()
    {
        // Меню выбора способа заполнения матрицы
        Console.WriteLine("Виберіть спосіб заповнення матриці:");
        Console.WriteLine("1 - Ввід вручну");
        Console.WriteLine("2 - Генерація випадкових чисел");
        Console.Write("Ваш вибір: ");
        int choice = int.Parse(Console.ReadLine());

        // Ввод размерности матрицы
        Console.Write("Введіть розмірність матриці n: ");
        int n = int.Parse(Console.ReadLine());

        // Инициализация матрицы A и вектора Z
        int[,] A = new int[n, n];
        int[] Z = new int[n];
        Random rand = new Random();

        // Заполнение матрицы A и вектора Z
        if (choice == 1)
        {
            Console.WriteLine("Введіть елементи матриці A:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"A[{i},{j}] = ");
                    A[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Введіть елементи вектора Z:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Z[{i}] = ");
                Z[i] = int.Parse(Console.ReadLine());
            }
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = rand.Next(1, 10); // Генерация случайных чисел от 1 до 9
                }
            }

            for (int i = 0; i < n; i++)
            {
                Z[i] = rand.Next(1, 20); // Генерация случайных чисел от 1 до 19
            }
        }

        // Нахождение максимального элемента в векторе Z
        int g = Z.Max();

        // Инициализация матрицы B
        int[,] B = new int[n, n];

        // Заполнение матрицы B
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                B[i, j] = g * A[i, j];
            }
        }

        // Замена диагональных элементов матрицы B на максимальные элементы столбцов
        for (int i = 0; i < n; i++)
        {
            int maxInColumn = B[0, i];
            for (int j = 1; j < n; j++)
            {
                if (B[j, i] > maxInColumn)
                {
                    maxInColumn = B[j, i];
                }
            }
            B[i, i] = maxInColumn;
        }

        // Вывод матрицы B
        Console.WriteLine("Матриця B після обчислень:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(B[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
