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

    internal Car GetById(int id)
    {
      string sql = @"
      SELECT * FROM cars
      WHERE id = @id;
      ";
      // REVIEW what is this line doing?
      Car car = _db.Query<Car>(sql, new { id }).FirstOrDefault();
      return car;
    }

    internal Car Create(Car newCar)
    {
      string sql = @"
      INSERT INTO cars
      (make, model, year, color, price, description, imgUrl)
      Values
      (@make, @model, @year, @color, @price, @description, @imgUrl);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newCar);
      newCar.Id = id;
      return newCar;
    }

    internal Car Update(Car carData)
    {
      string sql = @"
      UPDATE cars SET
        make = @make,
        model = @model,
        year = @year,
        price = @price,
        imgUrl = @imgUrl,
        description = @description,
        color = @color
      WHERE id = @id;
      ";
      int rowsAffected = _db.Execute(sql, carData);
      if (rowsAffected == 0)
      {
        throw new Exception("unable to edit car");
      }
      return carData;
    }

    internal void Delete(int id)
    {
      string sql = @"
      DELETE FROM cars WHERE id = @id;
      ";
      _db.Execute(sql, new { id });
    }
  }
}