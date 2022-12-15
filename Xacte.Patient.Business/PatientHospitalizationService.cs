using Xacte.Common.RAMQ;
using Xacte.Patient.Dto;

namespace Xacte.Patient.Business;
public class PatientHospitalizationService : IPatientHospitalizationService
{
	private Claim[] _mockClaims;

	public PatientHospitalizationService()
	{
		BuildMockClaims();
	}

	public GetPatientHospitalizationResponseObject GetPatientHospitalization(GetPatientHospitalizationDto getPatientHospitalizationDto)
	{
		GetPatientHospitalizationResponseObject responseObject = new GetPatientHospitalizationResponseObject();
		string numeroAssuranceMaladie = GetNumeroAssuranceMaladieByPatientId(getPatientHospitalizationDto.PatientId);

		if (!DateTime.TryParse(getPatientHospitalizationDto.FromDate, out DateTime fromDate) ||
		    NumeroAssuranceMaladie.IsSystemNAM(numeroAssuranceMaladie))
		{
			return responseObject;
		}

		foreach(var claim in _mockClaims)
		{
			if (!claim.DateEntree.HasValue) continue;

			if (IsIntensiveCare(claim.NoEtablissement) &&
			    getPatientHospitalizationDto.LocationNo == claim.NoEtablissement)
			{
				responseObject.HospitalizationDate = claim.DateEntree;
			}

			if (IsSameMetaLocation(getPatientHospitalizationDto.LocationNo, claim.NoEtablissement))
			{
				responseObject.HospitalizationDate = claim.DateEntree;
				return responseObject;
			}
		}

		return responseObject;
	}

	private bool IsIntensiveCare(string noEtablissement) => noEtablissement.StartsWith("6");

	private bool IsSameMetaLocation(string locationNo, string locationNo2)
	{
		if (IsOffice(locationNo))
		{
			locationNo += "0";
		}

		if (IsOffice(locationNo2))
		{
			locationNo2 += "0";
		}

		if (!int.TryParse(locationNo, out var loc) ||
			!int.TryParse(locationNo2, out var loc2))
		{
			return false;
		}

		return loc / 10 == loc2 / 10;
	}

	private bool IsOffice(string locationNo)
	{
		return false;
	}

	private void BuildMockClaims()
	{
		_mockClaims = new[]
		{
			new Claim
			{
				ClaimId = "1",
				DateEntree = DateTime.Today.AddDays(-5),
				NoEtablissement = "6000"
			},
			new Claim
			{
				ClaimId = "2",
				DateEntree = DateTime.Today.AddMonths(-1),
				NoEtablissement = "6033"
			},
			new Claim
			{
				ClaimId = "3",
				DateEntree = DateTime.Today.AddMonths(-3),
				NoEtablissement = "6999"
			}
		};
	}

	private string GetNumeroAssuranceMaladieByPatientId(string patientId)
	{
		if (patientId.Equals("1"))
		{
			return "ZZZZ01010112";
		}

		return "PREJ68112112";
	}

	public sealed class Claim
	{
		public string ClaimId { get; set; }
		public string NoEtablissement { get; set; }
		public DateTime? DateEntree { get; set; }
	}
}
