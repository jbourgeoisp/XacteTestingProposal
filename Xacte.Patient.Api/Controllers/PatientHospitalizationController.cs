using Microsoft.AspNetCore.Mvc;
using Xacte.Common;
using Xacte.Patient.Business;
using Xacte.Patient.Dto;

namespace Xacte.Patient.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class PatientHospitalizationController : ControllerBase
{
	private readonly IPatientHospitalizationService _patientHospitalizationService;

	public PatientHospitalizationController(IPatientHospitalizationService patientHospitalizationService)
	{
		_patientHospitalizationService = patientHospitalizationService;
	}

	[HttpGet]
	public IActionResult GetHospitalization([FromQuery]GetPatientHospitalizationDto getPatientHospitalizationDto)
	{
		GetPatientHospitalizationResponseObject getPatientHospitalizationResponseObject =
			_patientHospitalizationService.GetPatientHospitalization(getPatientHospitalizationDto);

		if (getPatientHospitalizationResponseObject is null)
		{
			return NotFound();
		}

		return Ok(new CallResultWithData<GetPatientHospitalizationResponseObject>(getPatientHospitalizationResponseObject));
	}
}
