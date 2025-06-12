public class Лисиця
{
    public bool Жив { get; private set; } = true;
    public int Голод { get; private set; } = 0;

    public void Охота(Клітинка[,] клітинки, int x, int y)
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
                    if (клітинки[nx, ny].Зайець != null)
                    {
                        Console.WriteLine($"Лисиця у ({x}, {y}) зловив зайця у ({nx}, {ny}).");
                        клітинки[nx, ny].Зайець = null;
                        Голод = 0;
                        return;
                    }
                }
            }
        }

        Голод++;
        if (Голод >= 2)
        {
            Жив = false;
            Console.WriteLine($"Лисиця у ({x}, {y}) загинув від голоду.");
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
                    if (клітинки[nx, ny].Лисиця != null && Голод == 0)
                    {
                        Console.WriteLine($"Лисиця у ({x}, {y}) відновився у ({nx}, {ny}).");
                        клітинки[nx, ny].Лисиця = new Лисиця();
                    }
                }
            }
        }
    }
}