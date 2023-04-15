using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TestVladimirPak;

public class VehicleData
{
    Helper helper = new Helper();

    #region SampleObjects

    Car car = new Car
    {
        VehicleId = 11,
        Chassis = new Chassis(4, 1, 500),
        Engine = new Engine("200", 3, "ESS", 654127),
        Transmission = new Transmission("Automatic", 6, "Eaton"),
        Weight = 400
    };

    Bus bus = new Bus
    {
        VehicleId = 21,
        Chassis = new Chassis(4, 1, 700),
        Engine = new Engine("200", 3, "Diesel", 456174),
        NumOfSeats = 30,
        Transmission = new Transmission("Manual", 4, "ISUZU")
    };

    Truck truck = new Truck
    {
        VehicleId = 31,
        Chassis = new Chassis(10, 2, 1500),
        Transmission = new Transmission("RTX", 6, "MAN"),
        Engine = new Engine("500", 10, "Diesel", 5479),
        WheelSize = 60
    };

    Scooter scooter = new Scooter
    {
        VehicleId = 41,
        Chassis = new Chassis(2, 1, 40),
        Engine = new Engine("150", 1.5, "HEV", 4560014),
        Transmission = new Transmission("Manual", 5, "HONDA"),
        ExtraSeat = false
    };

    #endregion

    public List<Vehicle> vehicles;

    public VehicleData()
    {
        vehicles = new List<Vehicle>() { scooter, car, truck, bus };
    }

    //Get All
    public List<Vehicle> GetAllVehicles()
    {
        return vehicles;
    }

    //GetById
    public Vehicle GetAutoByParameter(int id) 
    {
        var neededItem = vehicles.Where(item => item.VehicleId == id).SingleOrDefault();

        if (neededItem is null)
        {
            Console.WriteLine($"GetById: Vehicle with id: {id} cannot be found.");
        }

        return neededItem;
    }

    //GetByPropertyName
    public List<Vehicle> GetAutoByProperty(string property)
    {
        List<string> listOfProperties = new List<string>();
        List<Vehicle> finalResultWithVehicles = new List<Vehicle>();

        foreach (var item in vehicles)
        {
            listOfProperties = helper.GetPropertiesNameOfClass(item);

            bool oneFinding = listOfProperties.Any(x => x.Equals(property));

            if (oneFinding)
            {
                finalResultWithVehicles.Add(item);
            }
            else 
            {
                continue;
            }
        }

        if (finalResultWithVehicles.Count == 0 || property is null) 
        {
            Console.WriteLine($"GetByPropertyName: Parameter is not valid");
        }

        return finalResultWithVehicles;
    }

    //InsertNewVehicle
    public void AddAuto(Vehicle newVehicle) 
    {
        if (helper.AnyNullOrEmpty(newVehicle))
        {
            Console.WriteLine($"InsertNewVehicle: Vehicle cannot be added.");
        }

        vehicles.Add(newVehicle);
    }

    //UpdateVehicle
    public void UpdateAuto(Vehicle vehicleToEdit) 
    {
        if (helper.AnyNullOrEmpty(vehicleToEdit))
        {
            Console.WriteLine($"Update: Vehicle's information was not filled correctly. Please check inputs.");
            return;
        }

        var selectedVehicle = GetAutoByParameter(vehicleToEdit.VehicleId);

        if (selectedVehicle is null)
        {
            return;
        }

        selectedVehicle.Engine = vehicleToEdit.Engine;
        selectedVehicle.Transmission = vehicleToEdit.Transmission;
        selectedVehicle.Chassis = vehicleToEdit.Chassis;

        int index = vehicles.FindIndex(item => item.VehicleId == vehicleToEdit.VehicleId);

        vehicles[index] = selectedVehicle;
    }

    //DeleteById
    public void RemoveAuto(int vehicleId) 
    {
        var index = vehicles.FindIndex(item => item.VehicleId == vehicleId);

        if (index < 0) 
        {
            Console.WriteLine($"Vehicle with id: {vehicleId} cannot be found.");
        }

        vehicles.RemoveAt(index);
    }


}