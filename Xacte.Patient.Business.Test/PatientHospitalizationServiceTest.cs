using System.Collections;
using FluentAssertions;
using Xacte.Patient.Dto;

namespace Xacte.Patient.Business.Test;

public class PatientHospitalizationServiceTest
{
	private IPatientHospitalizationService _patientHospitalizationService;
	private readonly string _zzzzPatientId = "1";

	private sealed class GetPatientHospitalizationInIntensiveCareDtoData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[]
			{
				new GetPatientHospitalizationDto
				{
					PatientId = Guid.NewGuid().ToString(),
					FromDate = GetRandomDateStringInLast90Days(),
					LocationNo = "6000",
					ProfileId = Guid.NewGuid().ToString()
				}
			};
			yield return new object[]
			{
				new GetPatientHospitalizationDto
				{
					PatientId = Guid.NewGuid().ToString(),
					FromDate = GetRandomDateStringInLast90Days(),
					LocationNo = "6032",
					ProfileId = Guid.NewGuid().ToString()
				}
			};
			yield return new object[]
			{
				new GetPatientHospitalizationDto
				{
					PatientId = Guid.NewGuid().ToString(),
					FromDate = GetRandomDateStringInLast90Days(),
					LocationNo = "6033",
					ProfileId = Guid.NewGuid().ToString()
				}
			};
			yield return new object[]
			{
				new GetPatientHospitalizationDto
				{
					PatientId = Guid.NewGuid().ToString(),
					FromDate = GetRandomDateStringInLast90Days(),
					LocationNo = "6999",
					ProfileId = Guid.NewGuid().ToString()
				}
			};
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	public PatientHospitalizationServiceTest()
	{
		_patientHospitalizationService = new PatientHospitalizationService();
	}

	[Fact]
	public void GivenAGetPatientHospitalizationDto_WhenPatientIsNAMSystem_ThenDateHospitalizationReturnedIsNull()
	{
		// Arrange
		GetPatientHospitalizationDto dto = new GetPatientHospitalizationDto
		{
			PatientId = _zzzzPatientId
		};

		// Act
		GetPatientHospitalizationResponseObject responseObject =
			_patientHospitalizationService.GetPatientHospitalization(dto);

		// Assert
		responseObject.HospitalizationDate.Should().BeNull();
	}

	[Theory]
	[ClassData(typeof(GetPatientHospitalizationInIntensiveCareDtoData))]
	public void GivenListOfPatients_WhenPatientsAreInIntensiveCareLocation_ThenHospitalizationDateIsReturned(GetPatientHospitalizationDto dto)
	{
		// Act
		GetPatientHospitalizationResponseObject responseObject =
			_patientHospitalizationService.GetPatientHospitalization(dto);

		// Assert
		responseObject.HospitalizationDate.Should().NotBeNull();
	}

	private static string GetRandomDateStringInLast90Days()
	{
		return DateTime.UtcNow.AddDays(new Random().Next(90) * -1).ToString("yyyy-MM-dd");
	}
}