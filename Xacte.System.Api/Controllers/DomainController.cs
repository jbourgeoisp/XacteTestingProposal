using Microsoft.AspNetCore.Mvc;
using Xacte.Common;
using Xacte.System.Dto;

namespace Xacte.System.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class DomainController : ControllerBase
{
	private readonly ILogger<DomainController> _logger;

	public DomainController()
	{
	}

	public DomainController(ILogger<DomainController> logger)
	{
		_logger = logger;
	}

	[HttpGet(Name = "GetDomainById")]
	public IActionResult Get(string id)
	{
		return Ok(new CallResultWithData<DomainResponseObject>(new DomainResponseObject("b281aa48-3ba0-4144-8fd1-08b5c3be3862")));
	}
}
