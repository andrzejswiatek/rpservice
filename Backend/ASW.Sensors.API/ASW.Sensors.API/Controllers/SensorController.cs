using System.Collections.Generic;
using System.Threading.Tasks;
using ASW.Sensors.API.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASW.Sensors.API.Controllers
{
  /// <summary>Sensor controller</summary>
  [Route("api/[controller]")]
  [ApiController]
  public class SensorController : ControllerBase
  {
    /// <summary>Gets collection of sensors</summary>    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Sensor>))]
    public ActionResult<IEnumerable<Sensor>> Get()
    {
      return new[]
      {
        new Sensor {Name = "X1"},
        new Sensor {Name = "X2"}
      };
    }

    /// <summary>Gets sensor by name</summary>>
    /// <param name="name">Sensor name</param>
    /// <response code="200">Success</response>
    /// <response code="404">Sensor with given identifier not found</response>
    [HttpGet("{name}")]
    public ActionResult<Sensor> Get(string name)
    {
      return new Sensor {Name = name};
    }

    /// <summary>Creates the sensor</summary>>
    /// <param name="instance">Sensor instance</param>
    /// <response code="201">Sensor successfully created</response>
    /// <response code="400">Bad input message format</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Sensor))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public Sensor Post(Sensor instance)
    {
      return instance;
    }

    /// <summary>Updates the sensor</summary>>
    /// <param name="instance">Sensor instance</param>
    /// <response code="204">Sensor successfully updated</response>
    /// <response code="400">Bad input message format</response>
    /// <response code="404">Sensor with given identifier not found</response>
    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(Sensor instance)
    {
      return await Task.Run(() => NoContent());
    }

    /// <summary>Deletes sensor by name</summary>>
    /// <param name="name">Name of the sensor</param>
    /// <response code="204">Sensor successfully deleted</response>    
    /// <response code="404">Sensor with given name not found</response>    
    [HttpDelete("{name}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(string name)
    {
      return await Task.Run(() => NoContent());
    }
  }
}