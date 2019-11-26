using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ASW.Sensors.API.Controllers
{
  /// <summary>Sensor controller</summary>
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    /// <summary>GET api/values</summary>    
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] {"value1", "value2"};
    }

    /// <summary>GET api/values/5</summary>        
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    /// <summary>POST api/values</summary>    
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    /// <summary>PUT api/values/5</summary>    
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    /// <summary>DELETE api/values/5</summary>    
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}