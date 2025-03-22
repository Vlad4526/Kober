using System;
using System.IO;

class Program
{
    static void Main()
    {
        int[] array = new int[10];
        int choice;

        // Меню выбора источника данных
        Console.WriteLine("Выберите способ ввода данных:");
        Console.WriteLine("1. Из файла");
        Console.WriteLine("2. С клавиатуры");
        Console.WriteLine("3. Генерация случайных чисел");
        Console.Write("Ваш выбор: ");
        choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                array = ReadArrayFromFile("data.txt");
                break;
            case 2:
                array = ReadArrayFromKeyboard();
                break;
            case 3:
                array = GenerateRandomArray(10, -100, 100);
                break;
            default:
                Console.WriteLine("Неверный выбор. Используем случайные числа.");
                array = GenerateRandomArray(10, -100, 100);
                break;
        }

        // Вывод исходного массива
        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        // Обработка массива
        ProcessArray(array);

        // Вывод результирующего массива
        Console.WriteLine("Результирующий массив:");
        PrintArray(array);
    }

    // Функция для чтения массива из файла
    static int[] ReadArrayFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        int[] array = new int[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            array[i] = Convert.ToInt32(lines[i]);
        }
        return array;
    }

    // Функция для чтения массива с клавиатуры
    static int[] ReadArrayFromKeyboard()
    {
        Console.Write("Введите количество элементов массива: ");
        int length = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[length];

        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < length; i++)
        {
            Console.Write($"Элемент [{i}]: ");
            array[i] = Convert.ToInt32(Console.ReadLine());
        }
        return array;
    }

    // Функция для генерации случайного массива
    static int[] GenerateRandomArray(int length, int min, int max)
    {
        Random random = new Random();
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next(min, max + 1);
        }
        return array;
    }

    // Функция для вывода массива
    static void PrintArray(int[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }

    // Функция для обработки массива
    static void ProcessArray(int[] array)
    {
        int firstPositive = -1;
        int lastNegative = -1;

        // Поиск первого положительного и последнего отрицательного чисел
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > 0 && firstPositive == -1)
            {
                firstPositive = array[i];
            }
            if (array[i] < 0)
            {
                lastNegative = array[i];
            }
        }

        // Если нашли оба числа, вычисляем разницу и увеличиваем элементы первой половины
        if (firstPositive != -1 && lastNegative != -1)
        {
            int difference = firstPositive - lastNegative;
            for (int i = 0; i < array.Length / 2; i++)
            {
                array[i] += difference;
            }
        }
        else
        {
            Console.WriteLine("Не удалось найти первое положительное и последнее отрицательное числа.");
        }
    }
}
