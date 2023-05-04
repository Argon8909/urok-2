namespace ДЗ_12;

public partial class CardNew
{
    public delegate void MoneyOperation(decimal moneyDelta, decimal moneyBalance);

    /// <summary>
    /// Событие изменения счёта.
    /// </summary>
    public event MoneyOperation OnMoneyOperation;

    public delegate void CashbackChange(decimal CashbackDelta, decimal CashbackBalance);

    /// <summary>
    /// Событие изменения балланса кешбэка.
    /// </summary>
    public event CashbackChange OnCashbackChange;

    public delegate void ErrorOperations(decimal message);

    /// <summary>
    /// Событие ошибки
    /// </summary>
    public event ErrorOperations OnErrorOperations;

    public delegate void NotEnoughMoney(decimal message);

    /// <summary>
    /// Событие - недостаточно средств.
    /// </summary>
    public event NotEnoughMoney OnNotEnoughMoney;


    public List<string> PaymentsHistory { get; } = new();

    private decimal _moneyBalanse;

    /// <summary>
    /// Балланс
    /// </summary>
    public decimal MoneyBalanse
    {
        get => _moneyBalanse;
        private set { _moneyBalanse = value; }
    }

    /// <summary>
    /// метод оплаты со счёта
    /// </summary>
    /// <param name="canPay"></param>
    /// <param name="money">Сумма списания со счёта</param>
    public void Pay(Predicate<decimal> canPay, decimal money = 30)
    {
        if (canPay(MoneyBalanse))
        {
            MoneyBalanse -= money;
            OnMoneyOperation?.Invoke(-money, MoneyBalanse);
            PaymentsHistory.Add($"- {money} р. Баланс карты: {MoneyBalanse} р.");
            SetCashback(money);
        }
        else
        {
            OnErrorOperations.Invoke(MoneyBalanse);
        }
    }
}

/// <summary>
/// тут реализованна логика пополнения
/// </summary>
public partial class CardNew
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
            OnMoneyOperation.Invoke(money, MoneyBalanse);
        }
        else
        {
            //MoneyOperationsMessage?.Invoke($"Была попытка пополнения на {money} рублей!!! ");
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