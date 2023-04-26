namespace ДЗ___11___2;

public class Card
{
    public delegate void PayOperation(string message);

    public PayOperation? OnPayMessage;

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
            OnPayMessage?.Invoke($"Карта пополнена на {money} р. Баланс карты: {MoneyAmount} р.");
        }
        else
        {
            OnPayMessage?.Invoke($"Неверное значение!!! ");
        }
    }

    public void Pay(Predicate<int> canPay, int money = 30)
    {
        if (canPay(MoneyAmount))
        {
            MoneyAmount -= money;
            OnPayMessage?.Invoke($"Списано {money} р. Баланс карты: {MoneyAmount} р.");
            PaymentsHistory.Add($"- {money} р. Баланс карты: {MoneyAmount} р.");
            SetCashback(money / 10);
        }
        else
        {
            OnPayMessage?.Invoke($"Недостаточно средств на счету. Баланс карты: {MoneyAmount} р. ");
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