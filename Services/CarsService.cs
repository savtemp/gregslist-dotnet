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
  }
}