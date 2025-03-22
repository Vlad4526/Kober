using System;
using System.IO;

class Program
{
    static void Main()
    {
        
        string inputFile = "LAB2.txt";
        string outputFile = "LAB2.RES";

        try
        {
            
            string[] lines = File.ReadAllLines(inputFile);

            if (lines.Length == 0)
            {
                throw new InvalidOperationException("Файл пустой.");
            }

            string[] values = lines[0].Split();

            if (values.Length < 4)
            {
                throw new InvalidOperationException("Недостаточно значений в первой строке файла.");
            }

            
            double x_start = Convert.ToDouble(values[0]); 
            double y_start = Convert.ToDouble(values[1]); 
            double x_min = Convert.ToDouble(values[2]);   
            double x_max = Convert.ToDouble(values[3]);   

            
            double step = (x_max - x_min) / 7; // 8 значений -> 7 шагов
            double[] x_values = new double[8];
            for (int i = 0; i < 8; i++)
            {
                x_values[i] = x_min + i * step; // Вычисляем каждое значение x
            }

            // Обработка и запись результатов в выходной файл
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                // Запись заголовка
                writer.WriteLine(" x        y");
                writer.WriteLine("----------------");

                // Вычисление и запись значений функции
                foreach (double x in x_values)
                {
                    double y = x - Math.Sin(Math.PI * x); // Вычисляем значение y
                    writer.WriteLine($"{x,6:F3}  {y,8:F5}"); // Записываем x и y в файл
                }
            }

            // Сообщение об успешном завершении
            Console.WriteLine("Обработка завершена. Результаты сохранены в файле LAB2.RES");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Ошибка: Файл не найден.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Некорректный формат данных в файле.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}