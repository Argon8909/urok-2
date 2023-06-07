namespace Tasks;

public static class EventHandlers
{
    public static void OnMoneyOperationHandler(decimal moneyDelta, decimal moneyBalance)
    {
        if (moneyDelta < 0)
        {
            Console.WriteLine($"Со счёта списано {-moneyDelta} рублей. Баланс равен {moneyBalance}");
        }
        else if (moneyDelta > 0)
        {
            Console.WriteLine($"Счёт пополнен на {moneyDelta} рублей. Баланс равен {moneyBalance}");
        }
    }

    public static void OnCashbackChangeHandler(decimal CashbackDelta, decimal CashbackBalance)
    {
        if (CashbackDelta < 0)
        {
            Console.WriteLine(
                $"Со счёта кэшбэка списано {CashbackDelta} рублей. Баланс кэшбэка равен {CashbackBalance}");
        }
        else if (CashbackDelta > 0)
        {
            Console.WriteLine($"Кэшбэк пополнен на {CashbackDelta} рублей. Баланс кэшбэка равен {CashbackBalance}");
        }
    }

    public static void OnNotEnoughMoneyHandler(decimal writeOffValue, decimal moneyBalanse)
    {
        Console.WriteLine(
            $"Недостаточно средств на счету! Сумма списания {writeOffValue} рублей, сумма на балансе {moneyBalanse} рублей.");
    }

    public static void OnErrorOperationsHandler(decimal invalidValue)
    {
        if (invalidValue == 0)
        {
            Console.WriteLine($"Ошибка! была попытка пополнить счёт на 0 руб.");
        }
        else if (invalidValue < 0)
        {
            Console.WriteLine($"Ошибка! Нельзя пополнить счёт отрицательным значением!");
        }
    }

    [Obsolete]
    public static void OnOnHistoryOperationHandler1(decimal moneyDelta, decimal moneyBalance, bool errorOperation)
    {
        Dictionary<string, decimal> history = new();

        if (!errorOperation)
        {
            if (moneyDelta < 0)
            {
                history.Add($"Списано: {+moneyDelta} руб. Остаток: {moneyBalance}  руб.", moneyBalance);
                Program._historyDictionary.Add(history);
            }
            else if (moneyDelta > 0)
            {
                history.Add($"Зачислено: {moneyDelta} руб. Остаток: {moneyBalance}  руб.", moneyBalance);
                Program._historyDictionary.Add(history);
            }
        }
        else
        {
            history.Add(
                $"Недостаточно средств для списания! Необходимо минимум {+moneyDelta} руб. Баланс карты: {moneyBalance} р.",
                moneyBalance);
            Program._historyDictionary.Add(history);
        }
    }

    [Obsolete]
    public static void OnOnHistoryOperationHandler2(decimal moneyDelta, decimal moneyBalance, bool errorOperation)
    {
        Dictionary<string, decimal> history = new();

        if (!errorOperation)
        {
            if (moneyDelta < 0)
            {
                history.Add($"Списано: {+moneyDelta} руб. Остаток: {moneyBalance}  руб.", moneyBalance);
                lock (Program._historyDictionary)
                {
                    Program._historyDictionary.Add(history);
                }
            }
            else if (moneyDelta > 0)
            {
                history.Add($"Зачислено: {moneyDelta} руб. Остаток: {moneyBalance}  руб.", moneyBalance);
                lock (Program._historyDictionary)
                {
                    Program._historyDictionary.Add(history);
                }
            }
        }
        else
        {
            history.Add(
                $"Недостаточно средств для списания! Необходимо минимум {+moneyDelta} руб. Баланс карты: {moneyBalance} р.",
                moneyBalance);
            lock (Program._historyDictionary)
            {
                Program._historyDictionary.Add(history);
            }
        }
    }

    private static object historyLock = new object();

    public static void OnHistoryOperationHandler(decimal moneyDelta, decimal moneyBalance, bool errorOperation)
    {
        Dictionary<string, decimal> history = new();

        if (!errorOperation)
        {
            if (moneyDelta < 0)
            {
                //history.Add($"Списано: {Math.Abs(moneyDelta)} руб. Остаток: {moneyBalance} руб.", moneyBalance);

                history.Add($"Списано: {moneyDelta} руб. Остаток: {moneyBalance}  руб.", moneyBalance);
                bool lockAcquired = false;
                try
                {
                    if (Monitor.TryEnter(historyLock, TimeSpan.FromSeconds(5)))
                    {
                        lockAcquired = true;
                        Program._historyDictionary.Add(history);
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
                history.Add($"Зачислено: {moneyDelta} руб. Остаток: {moneyBalance}  руб.", moneyBalance);
                bool lockAcquired = false;
                try
                {
                    if (Monitor.TryEnter(historyLock, TimeSpan.FromSeconds(5)))
                    {
                        lockAcquired = true;
                        Program._historyDictionary.Add(history);
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
                $"Недостаточно средств для списания! Необходимо минимум {Math.Abs(moneyDelta)} руб. Баланс карты: {moneyBalance} р.",
                moneyBalance);

            bool lockAcquired = false;
            try
            {
                if (Monitor.TryEnter(historyLock, TimeSpan.FromSeconds(5)))
                {
                    lockAcquired = true;
                    Program._historyDictionary.Add(history);
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