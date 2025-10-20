using System.Security.Claims;
using API.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BuggyController : BaseAPIController
{
    [HttpGet("unauthorized")]

    public ActionResult<string> GetUnauthorized()
    {
        return Unauthorized();
    }

    [HttpGet("badrequest")]

    public ActionResult<string> GetBadRequest()
    {
        return BadRequest("Not a good request");
    }

    [HttpGet("notfound")]

    public ActionResult<string> GetnotFound()
    {
        return NotFound();
    }

    [HttpGet("internalerror")]

    public ActionResult<string> GetInternalError()
    {
        throw new Exception("This is a test exception");
    }

    [HttpPost("validationerror")]

    public ActionResult<string> GetValidationError(CreateProductDTO product)
    {
        return Ok();
    }

    [Authorize]

    [HttpGet("secret")]
    public IActionResult GetSecret()
    {
        var name = User.FindFirst(ClaimTypes.Name)?.Value;
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Ok("Hello" + name + "with the id of" + id);
    }


    
}
