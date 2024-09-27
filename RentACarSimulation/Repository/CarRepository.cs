using RentACarSimulation.Models;
using RentACarSimulation.Models.CarDetailDTO;
using RentACarSimulation.Repository;
using RentACarSimulation.Service;

namespace RentACarSimulation.Repository;

public class CarRepository
{
    List<Car> cars = new List<Car>()
    {
        new Car (1, 2, 3, 4, "Yeni", 10000, 2024, "34AS 2504", "OPEL", "Mokka", 1.500000),
        new Car (2, 3, 4, 5, "Yeni gibi", 10000, 2024, "34AB 1204", "BMW", "Corsa", 1.500000),
        new Car (3, 4, 5, 6, "Eski", 10000, 2024, "34BC 1304", "MERCEDES", "Mokka", 1.500000),
        new Car (4, 5, 6, 7, "Sıfır", 10000, 2024, "34HK 6704", "RANGE ROVER", "Discovery", 1.500000),
        new Car (5, 6, 7, 8, "Külüstür", 10000, 2024, "34MK 9004", "NISSAN", "Juke", 1.500000),
        new Car (6, 7, 8, 9, "Hasar Kayıtlı", 10000, 2024, "34LŞ 8604", "CITROEN", "C5", 1.500000),
        new Car (7, 8, 9, 10, "Ağır Hasarlı", 10000, 2024, "34GR 4104", "TOGG", "Sedan", 1.500000),
        new Car (8, 9, 10, 11, "Cillop gibi", 10000, 2024, "34UP 3404", "RENAULT", "Clio", 1.500000),
        new Car (9, 10, 11, 12, "Az kullanılmış", 10000, 2024, "34ÜR 1304", "VOLVO", "Xc-40", 1.500000),
        new Car (10, 11, 12, 13, "Çalışmıyor", 10000, 2024, "34ZR 0704", "AUDI", "X5", 1.500000)
    };

    public List<Car> GetAll()
    {
        return cars;
    }

    public Car Add(Car created)
    {
        cars.Add(created);
        return created;
    }

    public Car? Remove(int id)
    {
        Car? removedCar = GetById(id);

        if (removedCar is null)
        {
            return null;
        }
        cars.Remove(removedCar);
        return removedCar;
    }

    public Car? Update(Car updated)
    {
        Car? existingCar = GetById(updated.Id);
        if (existingCar is null)
        {
            return null;
        }

        return existingCar;
    }

    public Car? GetById(int id)
    {
        return cars.FirstOrDefault(car => car.Id == id);
    }

    private TransmissionRepository transmissionRepository = new TransmissionRepository();
    private ColorRepository colorRepository = new ColorRepository();
    private FuelRepository fuelRepository = new FuelRepository();

    public List<CarDetailDTO> GetDetailDTO()
    {
        var colors = colorRepository.GetAll();
        var transmissions = transmissionRepository.GetAll();
        var fuels = fuelRepository.GetAll();

        var result =
            from car in cars
            join color in colors on car.ColorId equals color.Id
            join transmission in transmissions on car.TransmissionId equals transmission.Id
            join fuel in fuels on car.FuelId equals fuel.Id
            
            select new CarDetailDTO(
                Id : car.Id,
                FuelName: fuel.Name,
                TransmissionName: transmission.Name,
                ColorName: color.Name,
                CarState: car.CarState,
                KiloMeter: car.KiloMeter,
                ModelYear: car.ModelYear,
                Plate: car.Plate,
                BrandName: car.BrandName,
                ModelName: car.ModelName,
                DailyPrice: car.DailyPrice
            );

        return result.ToList();
    }
}
