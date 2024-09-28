using RentACarSimulation.Models;
using RentACarSimulation.Service;
using RentACarSimulation.Repository;

class Program
{
    static void Main(string[] args)
    {

        CarService carService = new CarService();
        carService.GetAll();

    }
}
