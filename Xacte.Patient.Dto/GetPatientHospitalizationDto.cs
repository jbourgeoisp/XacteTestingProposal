namespace Xacte.Patient.Dto;

public class GetPatientHospitalizationDto
{
	public string PatientId { get; set; }
	public string FromDate { get; set; }
	public string ProfileId { get; set; }
	public string? LocationNo { get; set; }
}