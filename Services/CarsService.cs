using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gregslistFinal.Models;
using gregslistFinal.Repositories;

namespace gregslistFinal.Services
{
  public class CarsService
  {
    private readonly CarsRepository _carRepo;

    public CarsService(CarsRepository carRepo)
    {
      _carRepo = carRepo;
    }

    internal List<Car> GetAll()
    {
      return _carRepo.GetAll();
    }

    internal Car GetById(int id)
    {
      Car car = _carRepo.GetById(id);
      if (car == null)
      {
        throw new Exception("no car by that Id");
      }
      return car;
    }

    internal Car Create(Car newCar)
    {
      return _carRepo.Create(newCar);
    }
  }
}