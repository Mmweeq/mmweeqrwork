```csharp
public interface IAction
{
    void DoWork();
}

public interface IMeal
{
    void HaveMeal();
}

public interface IRest
{
    void TakeRest();
}

public class PersonWorker : IAction, IMeal, IRest
{
    public void DoWork() => Console.WriteLine("Человек выполняет работу");
    public void HaveMeal() => Console.WriteLine("Человек ест");
    public void TakeRest() => Console.WriteLine("Человек отдыхает");
}

public class MachineWorker : IAction
{
    public void DoWork() => Console.WriteLine("Машина выполняет работу");
}
```
