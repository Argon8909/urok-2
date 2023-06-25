using System;

namespace cancellation_token;

public  partial class Card
{
    public Card(decimal minBalance, decimal maxBalance, string cardName)
    {
        CardName = cardName;
        RouteToTheOffice = new Queue<PublicTransport>();
        RouteHome = new Stack<PublicTransport>();

        _minBalance = minBalance;
        _maxBalance = maxBalance;
        _banOnReplenishment = false;
        _banOnPayment = false;
    }

    /// <summary>
    /// метод оплаты со счёта
    /// </summary>
    /// <param name="money">Сумма списания со счёта</param>
    /// <param name="cardName"></param>
    /// <param name="canPay"></param>
    public bool Pay(decimal money)
    {
        if (MoneyBalance > _minBalance)
        {
            _banOnPayment = false;
        }
        
        if (MoneyBalance >= money && _banOnPayment == false)
        {
            MoneyBalance -= money;
            try
            {
                CheckBalance();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                PaymentsHistory.Add(
                    $"{CardName} ==>> Списано {money} р. Баланс на карте снизился ниже минимального значения. Баланс карты: {MoneyBalance} р.");
                _banOnReplenishment = true;
                throw;
            }
            //Math.Abs()
            OnMoneyOperation?.Invoke(-money, MoneyBalance, CardName);
            PaymentsHistory.Add($"Карта {CardName}. Списано {money} р. Баланс карты: {MoneyBalance} р.");
            OnHistoryOperation?.Invoke(-money, MoneyBalance, CardName);
            return true;
        }
        else
        {
            PaymentsHistory.Add(
                $"Карта {CardName}. Недостаточно средств для списания! Необходимо минимум {money} руб. Баланс карты: {MoneyBalance} р.");
            OnHistoryOperation?.Invoke(-money, MoneyBalance, CardName, true);
            OnNotEnoughMoney?.Invoke(money, MoneyBalance, CardName);
            return false;
        }
    }

    public void PrintPaymentsHistory()
    {
        Console.WriteLine($"История операций по {CardName}:");
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
        if (MoneyBalance < _maxBalance)
        {
            _banOnReplenishment = false;
        }

        if (money > 0 && _banOnReplenishment == false)
        {
            MoneyBalance += money;

            try
            {
                CheckBalance();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                PaymentsHistory.Add(
                    $"{CardName} ==>> Пополнено на {money} р. Превышен максимальный баланс на карте. Баланс карты: {MoneyBalance} р.");
                _banOnReplenishment = true;
                throw;
            }

            PaymentsHistory.Add($"{CardName} ==>> Пополнено на {money} р. Баланс карты: {MoneyBalance} р.");
            OnMoneyOperation?.Invoke(money, MoneyBalance, CardName);
            OnHistoryOperation?.Invoke(money, MoneyBalance, CardName);
        }
        else
        {
            OnErrorOperations?.Invoke(money, CardName);
        }
    }

    private void CheckBalance()
    {
        if (MoneyBalance < _minBalance)
        {
            throw new InsufficientBalanceException("--->>>Достигнут минимальный баланс на карте. Дальнейшее списание невозможно!");
        }

        if (MoneyBalance > _maxBalance)
        {
            throw new ExcessiveBalanceException(
                "--->>>Достигнут максимальный баланс на карте. Дальнейшее пополнение невозможно!");
        }
    }
}

