using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Имя файла с данными
        string fileName = "fuel_capacity.txt";

        try
        {
            // Чтение емкости бака из файла
            string[] lines = File.ReadAllLines(fileName);
            if (lines.Length == 0)
            {
                throw new InvalidOperationException("Файл пустой.");
            }

            int fuelCapacity = Convert.ToInt32(lines[0]);

            // Ввод данных от пользователя
            Console.Write("Введите вес груза (до 2000 кг): ");
            int cargoWeight = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите расстояние от А до В (км): ");
            int distanceAB = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите расстояние от В до С (км): ");
            int distanceBC = Convert.ToInt32(Console.ReadLine());

            // Расчет потребления палива в зависимости от веса груза
            double fuelConsumptionPerKm = GetFuelConsumption(cargoWeight);

            // Общее расстояние
            int totalDistance = distanceAB + distanceBC;

            // Общее потребление палива
            double totalFuelConsumption = totalDistance * fuelConsumptionPerKm;

            // Проверка, достаточно ли палива
            if (totalFuelConsumption <= fuelCapacity)
            {
                Console.WriteLine("Самолет сможет пролететь весь маршрут.");
            }
            else
            {
                Console.WriteLine("Самолету не хватит палива для полета по маршруту.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Ошибка: Файл не найден.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Некорректный формат данных.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    // Функция для определения потребления палива в зависимости от веса груза
    static double GetFuelConsumption(int cargoWeight)
    {
        if (cargoWeight <= 500)
        {
            return 1.0;
        }
        else if (cargoWeight <= 1000)
        {
            return 4.0;
        }
        else if (cargoWeight <= 1500)
        {
            return 7.0;
        }
        else if (cargoWeight <= 2000)
        {
            return 9.0;
        }
        else
        {
            throw new ArgumentException("Вес груза превышает максимально допустимый (2000 кг).");
        }
    }
}