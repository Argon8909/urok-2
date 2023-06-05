namespace HV_Lock;

public static class CardCasbackExtention
{
    public static void SetCasbackPercent(this Card card, decimal newSizeCashback)
    {
        card.CashbackSizePercent = newSizeCashback;
        Console.WriteLine("Был изменён размер кэшбэка на " + newSizeCashback);
    }
}