using System.Collections;
using FluentAssertions;
using Xacte.Patient.Dto;

namespace Xacte.Patient.Business.Test;

public class PatientHospitalizationServiceTest
{
	#region Properties

	private const string ZzzzPatientId = "1";
	private const string IntensiveCareLocationNo1 = "6000";
	private const string IntensiveCareLocationNo2 = "6001";
	private const string IntensiveCareLocationNo3 = "6002";

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
					LocationNo = IntensiveCareLocationNo1,
					ProfileId = Guid.NewGuid().ToString()
				}
			};
			yield return new object[]
			{
				new GetPatientHospitalizationDto
				{
					PatientId = Guid.NewGuid().ToString(),
					FromDate = GetRandomDateStringInLast90Days(),
					LocationNo = IntensiveCareLocationNo2,
					ProfileId = Guid.NewGuid().ToString()
				}
			};
			yield return new object[]
			{
				new GetPatientHospitalizationDto
				{
					PatientId = Guid.NewGuid().ToString(),
					FromDate = GetRandomDateStringInLast90Days(),
					LocationNo = IntensiveCareLocationNo3,
					ProfileId = Guid.NewGuid().ToString()
				}
			};
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	#endregion

	[Fact]
	public void GivenAGetPatientHospitalizationDto_WhenPatientIsNAMSystem_ThenDateHospitalizationReturnedIsNull()
	{
		// Arrange
		var service = CreateDefaultPatientHospitalizationService();
		GetPatientHospitalizationDto dto = new()
		{
			PatientId = ZzzzPatientId
		};

		// Act
		var responseObject = service.GetPatientHospitalization(dto);

		// Assert
		responseObject.HospitalizationDate.Should().BeNull();
	}

	[Theory]
	[ClassData(typeof(GetPatientHospitalizationInIntensiveCareDtoData))]
	public void GivenListOfPatients_WhenPatientsAreInIntensiveCareLocation_ThenHospitalizationDateIsReturned(
		GetPatientHospitalizationDto dto)
	{
		// Arrange
		var service = CreateDefaultPatientHospitalizationService();

		// Act
		var responseObject = service.GetPatientHospitalization(dto);

		// Assert
		responseObject.HospitalizationDate.Should().NotBeNull();
	}

	#region Setup

	private static PatientHospitalizationService CreateDefaultPatientHospitalizationService()
	{
		return new PatientHospitalizationService();
	}

	#endregion

	#region Private Methods

	private static string GetRandomDateStringInLast90Days()
	{
		return DateTime.UtcNow.AddDays(new Random().Next(90) * -1).ToString("yyyy-MM-dd");
	}

	#endregion
}