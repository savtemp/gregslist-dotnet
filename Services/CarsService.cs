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

    internal Car Update(Car update)
    {
      Car original = GetById(update.Id);
      original.Make = update.Make ?? original.Make;
      original.Model = update.Model ?? original.Model;
      original.Year = update.Year ?? original.Year;
      original.Price = update.Price ?? original.Price;
      original.ImgUrl = update.ImgUrl ?? original.ImgUrl;
      original.Description = update.Description ?? original.Description;
      original.Color = update.Color ?? original.Color;
      return _carRepo.Update(original);
    }

    internal string Delete(int id)
    {
      Car car = GetById(id);
      _carRepo.Delete(id);
      return $"Deleted the {car.Make} {car.Model}";
    }
  }
}