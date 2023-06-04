﻿using HV_Lock;

namespace ДЗ_12;

public static class EventHandler
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

    public static void OnOnHistoryOperationHandler(decimal moneyDelta, decimal moneyBalance, bool errorOperation)
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
}