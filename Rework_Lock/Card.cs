namespace Rework_Lock;

public class Card
{
    public delegate void HistoryOperation(decimal moneyDelta, decimal moneyBalance, bool errorOperation = false);

    /// <summary>
    /// Событие истории операций.
    /// </summary>
    public event HistoryOperation OnHistoryOperation;

    public delegate void MoneyOperation(decimal moneyDelta, decimal moneyBalance);

    /// <summary>
    /// Событие изменения счёта.
    /// </summary>
    public event MoneyOperation OnMoneyOperation;

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


    public Queue<PublicTransport> RouteToTheOffice { get; set; } //= null!;
    public Stack<PublicTransport> RouteHome { get; set; }//= null!;

    //public List<decimal> History { get; set; }
    public List<string> PaymentsHistory { get; } = new();

    private decimal _moneyBalance;

    public Card()
    {
        RouteToTheOffice = new Queue<PublicTransport>();
        RouteHome = new Stack<PublicTransport>();
    }

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
    /// <param name="money">Сумма списания со счёта</param>
    /// <param name="cardName"></param>
    /// <param name="canPay"></param>
    public bool Pay(decimal money, string cardName) 
    {
        if (MoneyBalance >= money)
        {
            MoneyBalance -= money;
            OnMoneyOperation?.Invoke(-money, MoneyBalance);
            PaymentsHistory.Add($"Карта {cardName}. Списано {money} р. Баланс карты: {MoneyBalance} р.");
            OnHistoryOperation?.Invoke(-money, MoneyBalance);
            return true;
        }
        else
        {
            PaymentsHistory.Add($"Карта {cardName}. Недостаточно средств для списания! Необходимо минимум {money} руб. Баланс карты: {MoneyBalance} р.");
            OnHistoryOperation?.Invoke(-money, MoneyBalance, true);
            OnNotEnoughMoney.Invoke(money, MoneyBalance);
            return false;
        }
    }

    public void PrintPaymentsHistory(string transportCard1Name)
    {
        Console.WriteLine($"История операций по {transportCard1Name}:");
        foreach (var history in PaymentsHistory)
        {
            Console.WriteLine(history);
        }

        Console.WriteLine("\n");
    }

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
            OnHistoryOperation?.Invoke(-money, MoneyBalance);
        }
        else
        {
            OnErrorOperations.Invoke(money);
        }
    }
}