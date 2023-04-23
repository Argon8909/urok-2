namespace ДЗ_11;


public class Card
{
    public delegate void PayOperation(string message);

    public event PayOperation? PayMessage;
    
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
            PayMessage($"Карта пополнена на {money} р. Баланс карты: {MoneyAmount} р.");
        }

        else
        {
            PayMessage($"Неверное значение!!! ");
        }
    }

    public void Pay(int money = 30)
    {
        if (MoneyAmount >= money)
        {
            MoneyAmount -= money;
            PayMessage($"Списано {money} р. Баланс карты: {MoneyAmount} р.");
        }
        else
        {
            PayMessage($"Недостаточно средств на счету. Баланс карты: {MoneyAmount} р. ");
        }
    }
}