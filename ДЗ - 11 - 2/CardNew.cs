namespace ДЗ___11___2;

public class CardNew
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

    public decimal CashbackMoneyBox { get; private set; }
    public List<string> PaymentsHistory { get; } = new();

    private decimal _moneyAmount;

    public decimal MoneyAmount
    {
        get => _moneyAmount;
        private set { _moneyAmount = value; }
    }

    /// <summary>
    /// метод оплаты со счёта
    /// </summary>
    /// <param name="canPay"></param>
    /// <param name="money">Сумма списания со счёта</param>
    public void Pay(Predicate<decimal> canPay, decimal money = 30)
    {
        if (canPay(MoneyAmount))
        {
            MoneyAmount -= money;
            OnMoneyOperation?.Invoke(-money, MoneyAmount);
            PaymentsHistory.Add($"- {money} р. Баланс карты: {MoneyAmount} р.");
            SetCashback(money);
        }
        else
        {
            OnErrorOperations.Invoke(MoneyAmount);
        }
    }

    /// <summary>
    /// Метод пополнения счёта
    /// </summary>
    /// <param name="money"></param>
    public void Replenishment(int money)
    {
        if (money > 0)
        {
            MoneyAmount += money;
            OnMoneyOperation.Invoke(money, MoneyAmount);
        }
        else
        {
            //MoneyOperationsMessage?.Invoke($"Была попытка пополнения на {money} рублей!!! ");
        }
    }

    private void SetCashback(decimal cashback)
    {
        decimal accrued = cashback / 10;
        CashbackMoneyBox += accrued;
        OnCashbackChange.Invoke(accrued, CashbackMoneyBox);
    }
}