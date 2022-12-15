using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xacte.Patient.Api.Controllers;
using Xacte.Patient.Business;
using Xacte.Patient.Dto;

namespace Xacte.Patient.Api.Test;

public class PatientHospitalizationControllerTest
{
	[Fact]
	public void GivenAnEmptyGetPatientHospitalizationDto_WhenGettingHospizationDate_ThenNotFoundIsReturned()
	{
		// Arrange
		Type expected = typeof(NotFoundResult);
		GetPatientHospitalizationDto getPatientHospitalizationDto = null;
		Mock<IPatientHospitalizationService> mockPatientHospitalizationService =
			CreateMockPatientHospitalizationService();
		mockPatientHospitalizationService.Setup(x => 
			x.GetPatientHospitalization(getPatientHospitalizationDto)).Returns<GetPatientHospitalizationResponseObject>(null);
		PatientHospitalizationController patientHospitalizationController = CreateDefaultPatientHospitalizationController(mockPatientHospitalizationService.Object);

		// Act
		IActionResult result = patientHospitalizationController.GetHospitalization(new GetPatientHospitalizationDto());

		// Assert
		result.GetType().Should().Be(expected);
	}

	#region Setup

	private static Mock<IPatientHospitalizationService> CreateMockPatientHospitalizationService()
	{
		return new Mock<IPatientHospitalizationService>();
	}

	private static PatientHospitalizationController CreateDefaultPatientHospitalizationController(
		IPatientHospitalizationService patientHospitalizationService)
	{
		return new PatientHospitalizationController(patientHospitalizationService);
	}

	#endregion
}