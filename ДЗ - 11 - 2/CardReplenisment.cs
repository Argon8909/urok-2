namespace ДЗ_12;

/// <summary>
/// тут реализованна логика пополнения
/// </summary>
public partial class Card
{
    public decimal CashbackMoneyBox { get; private set; }

    /// <summary>
    /// Метод пополнения счёта
    /// </summary>
    /// <param name="money"></param>
    public void Replenishment(decimal money)
    {
        if (money > 0)
        {
            MoneyBalanse += money;
            PaymentsHistory.Add($"Пополнено на {money} р. Баланс карты: {MoneyBalanse} р.");
            OnMoneyOperation.Invoke(money, MoneyBalanse);
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
    private void SetCashback(decimal cashback)
    {
        decimal accrued = cashback / 10;
        CashbackMoneyBox += accrued;
        OnCashbackChange.Invoke(accrued, CashbackMoneyBox);
    }
}