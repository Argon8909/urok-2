namespace ДЗ___11___2;


public class Card
{
    public delegate void PayOperation(string message);

    public PayOperation? OnPayMessage;

    private int _moneyAmount;

    public int MoneyAmount
    {
        get => _moneyAmount;
        private set
        {
            _moneyAmount = value;
        }
    }

    public List<string> PaymentsHistory { get; } = new List<string>();

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
        }
        else
        {
            OnPayMessage?.Invoke($"Недостаточно средств на счету. Баланс карты: {MoneyAmount} р. ");
        }
    }

    public int GetCashback()
    {
        return PaymentsHistory.Count * 5;
    }
}

/*
public class Card
{
    public delegate void PayOperation(string message);

    public PayOperation? OnPayMessage;

    private int _moneyAmount;

    public int MoneyAmount
    {
        get => _moneyAmount;
        private set
        {
            _moneyAmount = value;
        }
    }

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

    public void Pay(int money = 30)
    {
        if (MoneyAmount >= money)
        {
            MoneyAmount -= money;
            OnPayMessage?.Invoke($"Списано {money} р. Баланс карты: {MoneyAmount} р.");
        }
        else
        {
            OnPayMessage?.Invoke($"Недостаточно средств на счету. Баланс карты: {MoneyAmount} р. ");
        }
    }
}
*/