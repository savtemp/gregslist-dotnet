using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using gregslistFinal.Models;

namespace gregslistFinal.Repositories
{
  public class CarsRepository
  {
    private readonly IDbConnection _db;
    public CarsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Car> GetAll()
    {
      string sql = @"
        SELECT * FROM cars;
        ";
      List<Car> cars = _db.Query<Car>(sql).ToList();
      return cars;
    }
  }
}