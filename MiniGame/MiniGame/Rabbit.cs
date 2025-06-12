using System;

public class Зайець
{
    public bool Жив { get; private set; } = true;
    public int Голод { get; private set; } = 0;

    public void Їжа(Клітинка[,] клітинки, int x, int y)
    {
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                if (dx == 0 && dy == 0) continue;
                int nx = x + dx;
                int ny = y + dy;
                if (nx >= 1 && nx < клітинки.GetLength(0) - 1 && ny >= 1 && ny < клітинки.GetLength(1) - 1)
                {
                    if (клітинки[nx, ny].Трава != null)
                    {
                        Console.WriteLine($"Зайець у ({x}, {y}) з'їв траву у ({nx}, {ny}).");
                        клітинки[nx, ny].Трава = null;
                        Голод = 0;
                        return;
                    }
                }
            }
        }

        Голод++;
        if (Голод >= 1)
        {
            Жив = false;
            Console.WriteLine($"Зайець у ({x}, {y}) загинув від голоду.");
        }
    }

    public void Відтворення(Клітинка[,] клітинки, int x, int y)
    {
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                if (dx == 0 && dy == 0) continue;
                int nx = x + dx;
                int ny = y + dy;
                if (nx >= 1 && nx < клітинки.GetLength(0) - 1 && ny >= 1 && ny < клітинки.GetLength(1) - 1)
                {
                    if (клітинки[nx, ny].Зайець != null && клітинки[nx, ny].Трава != null)
                    {
                        Console.WriteLine($"Зайець у ({x}, {y}) відновився у ({nx}, {ny}).");
                        клітинки[nx, ny].Зайець = new Зайець();
                    }
                }
            }
        }
    }
}