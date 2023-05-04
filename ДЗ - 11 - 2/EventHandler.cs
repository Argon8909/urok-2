namespace ДЗ_12;

public static class EventHandler
{
    public static void OnMoneyOperationHandler(decimal moneyDelta, decimal moneyBalance)
    {
        if (moneyDelta < 0)
        {
            Console.WriteLine($"Со счёта списано {moneyDelta} рублей. Баланс равен {moneyBalance}");
        }
        else if (moneyDelta > 0)
        {
            Console.WriteLine($"Счёт пополнен на {moneyDelta} рублей. Баланс равен {moneyBalance}");
        }
    }

    public static void OnCashbackChangeHandler(decimal CashbackDelta, decimal CashbackBalance)
    {
        if (CashbackDelta < 0)
        {
            Console.WriteLine($"Со счёта кэшбэка списано {CashbackDelta} рублей. Баланс кэшбэка равен {CashbackBalance}");
        }
        else if (CashbackDelta > 0)
        {
            Console.WriteLine($"Кэшбэк пополнен на {CashbackDelta} рублей. Баланс кэшбэка равен {CashbackBalance}");
        }
    }
}