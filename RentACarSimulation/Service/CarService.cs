
using RentACarSimulation.Models;
using RentACarSimulation.Repository;

namespace RentACarSimulation.Service;


public class CarService
{
    CarRepository carRepository = new CarRepository();

    public void GetAll()
    {
        List<Car> cars = carRepository.GetAll();
        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }

    public void Add(Car car)
    {
        Car created = carRepository.Add(car);
        Console.WriteLine("Araba eklendi: ");
        Console.WriteLine(created);
    }

    public void Remove(int id)
    {
        Car? removedCar = carRepository.Remove(id);
        if (removedCar is null)
        {
            Console.WriteLine("Aradığınız araba bulunamadı!");
            return;
        }

        Console.WriteLine($"Sildiğiniz araba: {removedCar}");
    }

    public void Update(Car updatedCar)
    {
        Car? updated = carRepository.Update(updatedCar);
        if (updated is null)
        {
            Console.WriteLine("Güncellenecek araba bulunamadı!");
            return;
        }

        Console.WriteLine($"Araba güncellendi! {updated}");
    }

    public void GetById(int id)
    {
        Car? car = carRepository.GetById(id);
        if (car is null)
        {
            Console.WriteLine($"Aradığınız id'ye göre araba bulunamadı: {id}");
            return;
        }
        Console.WriteLine(car);
    }
}
