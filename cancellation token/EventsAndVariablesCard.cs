namespace cancellation_token;

public partial class Card
{
    public delegate void HistoryOperation(decimal moneyDelta, decimal moneyBalance, string cardName,
        bool errorOperation = false);

    /// <summary>
    /// Событие истории операций.
    /// </summary>
    public event HistoryOperation? OnHistoryOperation;

    public delegate void MoneyOperation(decimal moneyDelta, decimal moneyBalance, string cardName);

    /// <summary>
    /// Событие изменения счёта.
    /// </summary>
    public event MoneyOperation? OnMoneyOperation;

    public delegate void ErrorOperations(decimal invalidValue, string cardName);

    /// <summary>
    /// Событие ошибки
    /// </summary>
    public event ErrorOperations? OnErrorOperations;

    public delegate void NotEnoughMoney(decimal writeOffValue, decimal moneyBalance, string cardName);

    /// <summary>
    /// Событие - недостаточно средств.
    /// </summary>
    public event NotEnoughMoney? OnNotEnoughMoney;

    public Queue<PublicTransport> RouteToTheOffice { get; set; }
    public Stack<PublicTransport> RouteHome { get; set; }

    public List<string> PaymentsHistory { get; } = new();

    private readonly decimal _minBalance;
    private readonly decimal _maxBalance;

    /// <summary>
    /// Флаг запрета на пополнение баланса.
    /// </summary>
    private bool _banOnReplenishment;

    /// <summary>
    /// Флаг запрета на списание.
    /// </summary>
    private bool _banOnPayment;

    /// <summary>
    /// Балланс
    /// </summary>
    public decimal MoneyBalance { get; private set; }

    public readonly string CardName;
}