using Xacte.Patient.Dto;

namespace Xacte.Patient.Business;
public interface IPatientHospitalizationService
{
	GetPatientHospitalizationResponseObject? GetPatientHospitalization(GetPatientHospitalizationDto getPatientHospitalizationDto);
}
