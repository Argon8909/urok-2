namespace ДЗ___11___2;

public class Card
{
    public delegate void PayOperation(string message);

    public PayOperation? MoneyOperationsMessage;

    private int _moneyAmount;

    public int MoneyAmount
    {
        get => _moneyAmount;
        private set { _moneyAmount = value; }
    }

    public int CashbackMoneyBox { get; private set; }
    public List<string> PaymentsHistory { get; } = new ();

    public void Replenishment(int money)
    {
        if (money > 0)
        {
            MoneyAmount += money;
            MoneyOperationsMessage?.Invoke($"Карта пополнена на {money} р. Баланс карты: {MoneyAmount} р.");
        }
        else
        {
            MoneyOperationsMessage?.Invoke($"Была попытка пополнения на {money} рублей!!! ");
        }
    }

    public void Pay(Predicate<int> canPay, int money = 30)
    {
        if (canPay(MoneyAmount))
        {
            MoneyAmount -= money;
            MoneyOperationsMessage?.Invoke($"Списано {money} р. Баланс карты: {MoneyAmount} р.");
            PaymentsHistory.Add($"- {money} р. Баланс карты: {MoneyAmount} р.");
            SetCashback(money / 10);
        }
        else
        {
            MoneyOperationsMessage?.Invoke($"Недостаточно средств на счету. Баланс карты: {MoneyAmount} р. ");
        }
    }

    private void SetCashback(int cashback)
    {
        CashbackMoneyBox += cashback;
    }

    public int GetCashback() 
    {
        return CashbackMoneyBox; 
    }
}

/*

*/