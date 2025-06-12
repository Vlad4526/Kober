public class ЗнакЗодіаку
{
    private string знак;
    private string дата;
    private string знакЗодіаку;

    public string ПІБ { get; set; }
    public string GetЗнакЗодіаку()
    {
        return знакЗодіаку;
    }

    public void SetЗнакЗодіаку(string value)
    {
        знакЗодіаку = value;
    }

    public ЗнакЗодіаку(string знакЗодіаку)
    {
        SetЗнакЗодіаку(знакЗодіаку);
    }

    public DateTime ДеньНародження { get; set; }

    public ЗнакЗодіаку(string піб, string знакЗодіаку, DateTime деньНародження)
    {
        ПІБ = піб;
        SetЗнакЗодіаку(знакЗодіаку);
        ДеньНародження = деньНародження;
    }

    public ЗнакЗодіаку(string? піб, string знак, string дата)
    {
        ПІБ = піб;
        this.знак = знак;
        this.дата = дата;
    }
}
