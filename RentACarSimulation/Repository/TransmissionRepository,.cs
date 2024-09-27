namespace RentACarSimulation.Repository;
using RentACarSimulation.Models;

public class TransmissionRepository
{
    List<Transmission> transmissions = new List<Transmission>()
    {
        new Transmission (1, "Otomatik"),
        new Transmission (2, "Manuel"),
    };

    public List<Transmission> GetAll()
    {
        return transmissions;
    }

    public Transmission Add(Transmission created)
    {
        transmissions.Add(created);
        return created;
    }

    public Transmission? Remove(int id)
    {
        Transmission? removedTransmission = GetById (id);
        if (removedTransmission is null)
        {
            return null;
        }
        transmissions.Remove(removedTransmission);
        return removedTransmission;
    }

    public Transmission? Update(Transmission updatedTransmission)
    {
        Transmission? existingTransmission = GetById(updatedTransmission.Id);
        if (updatedTransmission is null)
        {
            return null;
        }

        return updatedTransmission;
    }

    public Transmission? GetById(int id)
    {
        Transmission? transmission1 = null;
        foreach (Transmission transmission in transmissions)
        {
            if (transmission.Id == id)
            {
                transmission1 = transmission;
            }
        }

        if (transmission1 is null)
        {
            return null;
        }

        return transmission1;
    }
}

