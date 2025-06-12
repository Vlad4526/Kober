public class Платіж
{
    public string РахунокПлатника { get; set; }
    public string РахунокОтримувача { get; set; }
    public DateTime Дата { get; set; }
    public decimal Сума { get; set; }

    public Платіж(string платник, string отримувач, DateTime дата, decimal сума)
    {
        РахунокПлатника = платник;
        РахунокОтримувача = отримувач;
        Дата = дата;
        Сума = сума;
    }
}
