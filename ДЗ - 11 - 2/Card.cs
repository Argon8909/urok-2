namespace ДЗ_12;

public partial class Card
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

    public delegate void ErrorOperations(decimal invalidValue);

    /// <summary>
    /// Событие ошибки
    /// </summary>
    public event ErrorOperations OnErrorOperations;

    public delegate void NotEnoughMoney(decimal writeOffValue, decimal moneyBalanse);

    /// <summary>
    /// Событие - недостаточно средств.
    /// </summary>
    public event NotEnoughMoney OnNotEnoughMoney;


    public List<string> PaymentsHistory { get; } = new();

    private decimal _moneyBalance;

    /// <summary>
    /// Балланс
    /// </summary>
    public decimal MoneyBalance
    {
        get => _moneyBalance;
        private set { _moneyBalance = value; }
    }

    /// <summary>
    /// метод оплаты со счёта
    /// </summary>
    /// <param name="canPay"></param>
    /// <param name="money">Сумма списания со счёта</param>
    public bool Pay(decimal money) //Predicate<decimal> canPay
    {
        if (MoneyBalance >= money)
        {
            MoneyBalance -= money;
            OnMoneyOperation?.Invoke(-money, MoneyBalance);
            PaymentsHistory.Add($"Списано {money} р. Баланс карты: {MoneyBalance} р.");
            SetCashback(money);
            return true;
        }
        else
        {
            PaymentsHistory.Add(
                $"Недостаточно средств для списания! Необходимо минимум {money} руб. Баланс карты: {MoneyBalance} р.");
            OnNotEnoughMoney.Invoke(money, MoneyBalance);
            return false;
        }
    }

    public void PrintPaymentsHistory()
    {
        Console.WriteLine("История операций:");
        foreach (var history in PaymentsHistory)
        {
            Console.WriteLine(history);
        }

        Console.WriteLine("\n");
    }
}