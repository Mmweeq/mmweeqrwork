```csharp
using System;

public interface IWriter
{
    void Write(string text);
}

public interface IScannerDevice
{
    void Capture(string text);
}

public interface ISender
{
    void Send(string text);
}

// Универсальное устройство поддерживает все функции
public class MultiFunctionDevice : IWriter, IScannerDevice, ISender
{
    public void Write(string text) => Console.WriteLine("Отправка на печать: " + text);
    public void Capture(string text) => Console.WriteLine("Сканирование документа: " + text);
    public void Send(string text) => Console.WriteLine("Передача факсом: " + text);
}

// Упрощённое устройство реализует только печать
public class SimpleWriter : IWriter
{
    public void Write(string text) => Console.WriteLine("Печать документа: " + text);
}
```
