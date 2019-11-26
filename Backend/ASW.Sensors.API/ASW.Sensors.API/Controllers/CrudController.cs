using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ASW.Sensors.API.DataTransfer;
using ASW.Sensors.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASW.Sensors.API.Controllers
{
  /// <summary>Class representing base WebApi controller</summary>
  /// <typeparam name="TDomainType">Implementation type</typeparam>
  /// <typeparam name="TDataTransfer">Implementation type</typeparam>  
  [ApiController]
  [Route("api/[controller]")]
  public abstract class CrudController<TDomainType, TDataTransfer> : ControllerBase
    where TDomainType : class, IEntity
    where TDataTransfer : class, IDataTransferObject
  {
    /// <summary>Logger instance</summary>
    protected ILogger Logger;

    /// <summary>Data transfer type name</summary>
    protected string DataTransferTypeName => nameof(TDataTransfer);

    /// <summary>Base controller constructor</summary>    
    /// <param name="logger">Logger</param>
    protected CrudController(
      ILogger logger)
    {
      Logger = logger;
    }

    /// <response code="200">Success</response>
    [HttpGet]
    public virtual Task<ActionResult<IEnumerable<TDataTransfer>>> GetAll()
    {
      Logger.LogTrace($"Getting collection of {DataTransferTypeName}'s");
      throw new NotImplementedException();      
    }

    /// <summary>Gets items list using clause</summary>
    /// <param name="clause"></param>
    /// <returns></returns>
    protected virtual Task<IList<TDataTransfer>> GetItemsUsingClause(Expression<Func<TDomainType, bool>> clause)
    {
      throw new NotImplementedException();
    }

    /// <response code="200">OK</response>
    /// <response code="404">Resource not found</response>        
    [HttpGet("{id}")]
    public virtual Task<ActionResult<TDataTransfer>> GetById(long id)
    {
      Logger.LogTrace($"Getting {DataTransferTypeName} by id={id}");
      throw new NotImplementedException();
    }

    /// <response code="201">Resource created</response>
    /// <response code="400">Bad format</response>
    /// <response code="422">Cannot insert existing entity</response>
    [HttpPost]    
    public virtual Task<ActionResult<TDataTransfer>> Post(TDataTransfer instance)
    {
      Logger.LogTrace($"Creating {DataTransferTypeName}");
      throw new NotImplementedException();
    }

    /// <response code="204">No content</response>
    /// <response code="400">Bad format</response>
    /// <response code="404">Not found</response>
    /// <response code="409">Conflict</response>
    [HttpPut]    
    public virtual Task<ActionResult> Put(TDataTransfer instance)
    {
      Logger.LogTrace($"Updating {DataTransferTypeName}");

      throw new NotImplementedException();
    }

    /// <response code="204">No content</response>
    /// <response code="404">Not found</response>
    /// <response code="409">Forbidden</response>
    [HttpDelete("{id}")]
    public virtual Task<ActionResult> Delete(int id)
    {
      Logger.LogTrace($"Deleting {DataTransferTypeName} using id={id}");

      throw new NotImplementedException();
    }    

    /// <summary>Gets message when object with given identifier cannot be found</summary>    
    protected NotFoundObjectResult GetNotFoundResultFor(long id)
    {
      return NotFound($"No object found with given identifier: {id}");
    }
  }
}