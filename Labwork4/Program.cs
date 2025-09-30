```csharp
TransportCreator? factory = null;
IVehicle? vehicle = null;
factory?.Build(vehicle);

public interface IVehicle
{
    void Drive();
    void Refuel();
}

public class Auto(string brand, int topSpeed) : IVehicle
{
    public string Brand { get; set; } = brand;
    public int TopSpeed { get; set; } = topSpeed;

    public void Drive() => Console.WriteLine("Автомобиль движется");
    public void Refuel() => Console.WriteLine("Автомобиль заправлен");
}

public class Bike(string brand, int topSpeed) : IVehicle
{
    public string Brand { get; set; } = brand;
    public int TopSpeed { get; set; } = topSpeed;

    public void Drive() => Console.WriteLine("Мотоцикл мчится");
    public void Refuel() => Console.WriteLine("Мотоцикл заправлен");
}

public class Airplane(string brand, int topSpeed) : IVehicle
{
    public string Brand { get; set; } = brand;
    public int TopSpeed { get; set; } = topSpeed;

    public void Drive() => Console.WriteLine("Самолёт взлетает");
    public void Refuel() => Console.WriteLine("Самолёт заправлен");
}

public class Boat(string brand, int topSpeed) : IVehicle
{
    public string Brand { get; set; } = brand;
    public int TopSpeed { get; set; } = topSpeed;

    public void Drive() => Console.WriteLine("Корабль плывёт");
    public void Refuel() => Console.WriteLine("Корабль заправлен");
}

public abstract class TransportCreator
{
    public IVehicle Build(IVehicle transport) => transport;
}

public abstract class AutoFactory(string brand)
{
    public Auto? MakeCar(Auto? car) => car;
}

public abstract class BikeFactory
{
    public Bike MakeBike(Bike bike) => bike;
}

public abstract class AirplaneFactory
{
    public Airplane MakePlane(Airplane plane) => plane;
}

public abstract class BoatFactory
{
    public Boat MakeBoat(Boat boat) => boat;
}
```
