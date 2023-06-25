namespace cancellation_token;

public static class EventHandlers
{
    public static void OnMoneyOperationHandler(decimal moneyDelta, decimal moneyBalance, string cardName)
    {
        if (moneyDelta < 0)
        {
            Console.WriteLine($"{cardName} >>>> Со счёта списано {-moneyDelta} рублей. Баланс равен {moneyBalance}");
        }
        else if (moneyDelta > 0)
        {
            Console.WriteLine($"{cardName} >>>> Счёт пополнен на {moneyDelta} рублей. Баланс равен {moneyBalance}");
        }
    }

    public static void OnNotEnoughMoneyHandler(decimal writeOffValue, decimal moneyBalanse, string cardName)
    {
        Console.WriteLine(
            $"{cardName} >->-> Недостаточно средств на счету! Сумма списания {writeOffValue} рублей, сумма на балансе {moneyBalanse} рублей.");
    }

    public static void OnErrorOperationsHandler(decimal invalidValue, string cardName)
    {
        if (invalidValue == 0)
        {
            Console.WriteLine($"{cardName} >+>+> Ошибка! была попытка пополнить счёт на 0 руб.");
        }
        else if (invalidValue < 0)
        {
            Console.WriteLine($"{cardName} >+>+> Ошибка! Нельзя пополнить счёт отрицательным значением!");
        }
    }

    /*
 Написать потокобезопасный прием платежей и вывод транзакций по транспортной карте.

public List<decimal> History { get; set; } - список со всеми транзакциями.

Нужно обеспечить безопасное добавление платежей в 2 потока и считывание истории платежей в 2 потока.
 */
    private static object historyLock = new object();

    public static void OnHistoryOperationHandler(decimal moneyDelta, decimal moneyBalance, string cardName,
        bool errorOperation)
    {
        Dictionary<string, decimal> history = new();

        if (!errorOperation)
        {
            if (moneyDelta < 0)
            {
                //history.Add($"Списано: {Math.Abs(moneyDelta)} руб. Остаток: {moneyBalance} руб.", moneyBalance);

                history.Add($"{cardName}--> Списано: {moneyDelta} руб. Остаток: {moneyBalance}  руб.", moneyBalance);
                bool lockAcquired = false;
                try
                {
                    if (Monitor.TryEnter(historyLock, TimeSpan.FromSeconds(1)))
                    {
                        lockAcquired = true;
                        Program.HistoryAllCard.Add(history);
                    }
                    else
                    {
                        // Обработка неудачного получения блокировки
                    }
                }
                finally
                {
                    if (lockAcquired)
                        Monitor.Exit(historyLock);
                }
            }
            else if (moneyDelta > 0)
            {
                history.Add($"{cardName}--> Зачислено: {moneyDelta} руб. Остаток: {moneyBalance}  руб.", moneyBalance);
                bool lockAcquired = false;
                try
                {
                    if (Monitor.TryEnter(historyLock, TimeSpan.FromSeconds(1)))
                    {
                        lockAcquired = true;
                        Program.HistoryAllCard.Add(history);
                    }
                    else
                    {
                        // Обработка неудачного получения блокировки
                    }
                }
                finally
                {
                    if (lockAcquired)
                        Monitor.Exit(historyLock);
                }
            }
        }
        else
        {
            history.Add(
                $"{cardName}--> Недостаточно средств для списания! Необходимо минимум {Math.Abs(moneyDelta)} руб. Баланс карты: {moneyBalance} р.",
                moneyBalance);

            bool lockAcquired = false;
            try
            {
                if (Monitor.TryEnter(historyLock, TimeSpan.FromSeconds(1)))
                {
                    lockAcquired = true;
                    Program.HistoryAllCard.Add(history);
                }
                else
                {
                    // Обработка неудачного получения блокировки
                }
            }
            finally
            {
                if (lockAcquired)
                    Monitor.Exit(historyLock);
            }
        }
    }
}