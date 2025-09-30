```csharp
using System;
using System.Collections.Generic;

public class Account
{
    public string FullName { get; set; }
    public string Mail { get; set; }
    public string AccessLevel { get; set; }

    public Account(string fullName, string mail, string accessLevel)
    {
        FullName = fullName;
        Mail = mail;
        AccessLevel = accessLevel;
    }

    public void Edit(string fullName, string mail, string accessLevel)
    {
        FullName = fullName;
        Mail = mail;
        AccessLevel = accessLevel;
    }

    public override string ToString()
    {
        return $"{FullName} [{Mail}] — {AccessLevel}";
    }
}

public class AccountService
{
    private List<Account> _accounts = new List<Account>();

    public void Register(Account account)
    {
        _accounts.Add(account);
        Console.WriteLine($"Аккаунт создан: {account}");
    }

    public void Delete(string mail)
    {
        var acc = FindByMail(mail);
        if (acc != null)
        {
            _accounts.Remove(acc);
            Console.WriteLine($"Аккаунт с почтой {mail} удалён");
        }
        else
        {
            Console.WriteLine($"Аккаунт с почтой {mail} не найден");
        }
    }

    public void Change(string mail, string newFullName, string newMail, string newAccess)
    {
        var acc = FindByMail(mail);
        if (acc != null)
        {
            acc.Edit(newFullName, newMail, newAccess);
            Console.WriteLine($"Аккаунт изменён: {acc}");
        }
        else
        {
            Console.WriteLine($"Аккаунт с почтой {mail} не найден");
        }
    }

    public void ShowAll()
    {
        Console.WriteLine("Список аккаунтов:");
        foreach (var acc in _accounts)
        {
            Console.WriteLine(acc);
        }
    }

    private Account FindByMail(string mail)
    {
        return _accounts.Find(a => a.Mail == mail);
    }
}

public class Program
{
    public static void Main()
    {
        var accountService = new AccountService();

        var acc1 = new Account("Иван Петров", "ivan@mail.com", "Администратор");
        var acc2 = new Account("Мария Иванова", "maria@mail.com", "Пользователь");

        accountService.Register(acc1);
        accountService.Register(acc2);

        accountService.ShowAll();

        accountService.Change("maria@mail.com", "Мария И.", "m.ivanova@mail.com", "Модератор");

        accountService.Delete("ivan@mail.com");

        accountService.ShowAll();
    }
}
```
