using System;
using System.Collections.Generic;
using ElectronicShop;
using System.Linq;
using ElectronicShop.DataStores;
using System.Threading.Tasks;
using ElectronicShop.Queries;
using Microsoft.AspNetCore.Mvc;
using ElectronicShop.Models;
using ElectronicShop.Commands;

namespace ElectronicShop.Controllers
{
// [ApiVersion("1")]
// [Route("api/v{version:ApiVersion}/[controller]")]
[Route("api/v{version:ApiVersion}/[controller]")]
  public class ElectronicsController : ControllerBase
  {
    private readonly IElectronicQueries _queries;
    private readonly IElectronicCommands _commands;

    public ElectronicsController(IElectronicQueries queries, IElectronicCommands commands) {
      _queries = queries;
      _commands = commands;
    }

    [HttpGet]
    public IActionResult FindElectronics()
    {
      var result = _queries.GetElectronics();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult FindElectronicById(Guid id)
    {
      if (id == null)
      {
        return BadRequest("Missing Required Parameter/s");
      }

      var result = _queries.GetElectronic(id);
      return Ok(result);

    }

    [HttpPost]
    public IActionResult CreateElectronic([FromBody]ElectronicModel electronicData)
    {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }
      var result = _commands.CreateElectronic(electronicData);
      return Ok(result);
    }
    
    [HttpPatch("{id}")]
    public IActionResult UpdateElectronicById(Guid id, [FromBody] ElectronicDescriptionModel electronicDescriptionData)
    {
      if (id == null)
      {
        return BadRequest("Missing Required Parameter/s");
      }

      var result =_commands.UpdateElectronicById(id, electronicDescriptionData);
      return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteElectronicById(Guid id)
    {
      if (id == null)
      {
        return BadRequest("Missing Required Parameter/s");
      }
      var result = _commands.DeleteElectronicById(id);
      if (result == null)
      {
        return NotFound($"Electronics for {id} not found.");
      }
      return Ok(result);
    }

  }
}
