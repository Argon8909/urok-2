namespace HV_Lock;

/// <summary>
/// тут реализованна логика пополнения
/// </summary>
public partial class Card
{
    private decimal _cashbackSizePercent = 11;

    public decimal CashbackSizePercent
    {
        get => _cashbackSizePercent;
        set => _cashbackSizePercent = value;
    }


    public decimal CashbackMoneyBox { get; private set; }

    /// <summary>
    /// Метод пополнения счёта
    /// </summary>
    /// <param name="money"></param>
    public void Replenishment(decimal money)
    {
        if (money > 0)
        {
            MoneyBalance += money;
            PaymentsHistory.Add($"Пополнено на {money} р. Баланс карты: {MoneyBalance} р.");
            OnMoneyOperation.Invoke(money, MoneyBalance);
        }
        else
        {
            OnErrorOperations.Invoke(money);
        }
    }

    /// <summary>
    /// Метод пополнения кэшбэка.
    /// </summary>
    /// <param name="cashback"></param>
    private void SetCashback(decimal sum)
    {
        decimal cashback = sum * (CashbackSizePercent / 100);
        CashbackMoneyBox += cashback;
        OnCashbackChange.Invoke(cashback, CashbackMoneyBox);
    }
}