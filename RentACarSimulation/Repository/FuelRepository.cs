
namespace RentACarSimulation.Repository;
using RentACarSimulation.Models;

public class FuelRepository
{
    List<Fuel> fuels = new List<Fuel>()
    {
        new Fuel(1,"Dizel"),
        new Fuel(2,"Hibrit"),
        new Fuel(3,"Benzin"),
        new Fuel(4,"Gaz"),
        new Fuel(5,"Elektrik"),
        new Fuel(6,"Euro dizel"),
        new Fuel(7,"Elektrik"),
        new Fuel(8,"Benzin"),
        new Fuel(9,"Gaz"),
        new Fuel(10,"Benzin"),
    };

    public List<Fuel> GetAll()
    {
        return fuels;
    }

    public Fuel Add(Fuel created)
    {
        fuels.Add(created);
        return created;
    }

    public Fuel? Remove(int id)
    {
        Fuel? removedFuel = GetById(id);
        if (removedFuel is null)
        {
            return null;
        }
        fuels.Remove(removedFuel);
        return removedFuel;
    }


    public Fuel? Update(Fuel updated)
    {
        Fuel? updatedFuel = GetById(updated.Id);
        if (updatedFuel is null)
        {
            return null;
        }
        return updatedFuel;
    }

    public Fuel? GetById(int id)
    {
        Fuel? fuel1 = null;
        foreach (Fuel fuel in fuels)
        {
            if (fuel.Id == id)
            {
                fuel1 = fuel;
            }
        }

        if (fuel1 is null)
        {
            return null;
        }

        return fuel1;
    }
}
        