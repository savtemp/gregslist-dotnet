using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gregslistFinal.Models;
using gregslistFinal.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslistFinal.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    private readonly CarsService _carsService;

    public CarsController(CarsService carsService)
    {
      _carsService = carsService;
    }

    [HttpGet]
    public ActionResult<List<Car>> GetAll()
    {
      try
      {
        List<Car> cars = _carsService.GetAll();
        return cars;
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Car> GetById(int id)
    {
      try
      {
        return Ok(_carsService.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try
      {
        Car car = _carsService.Create(newCar);
        return Ok(car);
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Car> Update(int id, [FromBody] Car update)
    {
      try
      {
        update.Id = id;
        return Ok(_carsService.Update(update));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_carsService.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}