```csharp
Car car = new Car("Mercedes", "W210", DateTime.Now.AddYears(-12), 5, "АКПП");
car.EngineOn();
car.EngineOff();

Motorcycle moto = new Motorcycle("Yamaha", "Круизер", DateTime.Now.AddYears(-2), "chopper", true);
moto.EngineOn();
moto.EngineOff();

Vehicle auto = new Vehicle("Nissan", "Almera", DateTime.Now.AddYears(-8));

Parking parking = new Parking();
parking.AddVehicle(auto);
parking.RemoveVehicle(auto);

TransportFleet fleet = new TransportFleet();
fleet.IncludeGarage(parking);
fleet.FindVehicle("Yamaha");


public class Vehicle(string brand, string model, DateTime productionDate)
{
    public string Brand { get; set; } = brand;
    private string Model { get; set; } = model;
    private DateTime ProductionDate { get; set; } = productionDate;

    public void EngineOn() =>
        Console.WriteLine("Мотор успешно завелся");

    public void EngineOff() =>
        Console.WriteLine("Мотор остановлен");
}

public class Car(string brand, string model, DateTime productionDate, int doors, string transmission) 
    : Vehicle(brand, model, productionDate)
{
    public int Doors { get; set; } = doors;
    public string Transmission { get; set; } = transmission;
}

public class Motorcycle(string brand, string model, DateTime productionDate, string type, bool hasTrunk) 
    : Vehicle(brand, model, productionDate)
{
    public string Type { get; set; } = type;
    public bool HasTrunk { get; set; } = hasTrunk;
}

public class Parking
{
    public readonly List<Vehicle> Vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle transport) =>
        Vehicles.Add(transport);

    public void RemoveVehicle(Vehicle transport) =>
        Vehicles.Remove(transport);
}

public class TransportFleet
{
    private readonly List<Parking> _garages = new List<Parking>();
    private readonly List<Vehicle> _allVehicles = new List<Vehicle>();
    
    public void IncludeGarage(Parking parking) =>
        _garages.Add(parking);

    public void ExcludeGarage(Parking parking) =>
        _garages.Remove(parking);
    
    public Vehicle FindVehicle(string brand)
    {
        foreach (var v in _allVehicles)
        {
            if (brand == v.Brand)
                return v;
        }
        return null;
    }
}
```
