namespace Xacte.System.Dto;
public class DomainResponseObject
{
	public string DomainId { get; set; }
	public string AccountId { get; set; }
	public string DomainType { get; set; }
	public string Description { get; set; }
	public string PatientIdScheme { get; set; }
	public string PatientModes { get; set; }
	public string Status { get; set; }
	public string DefaultLanguage { get; set; }
	public bool? Enabled { get; set; }
	public bool DateExpirationRequise { get; set; }
	public bool ValiderDateExpiration { get; set; }
	public bool UtiliserDernierDiagnostic { get; set; }
	public bool UtiliserDerniereDateCsst { get; set; }
	public bool UtiliserDerniereDateHosp { get; set; }
	public bool DefaultDomain { get; set; }

	public DomainResponseObject(string domainId)
	{
		DomainId = domainId;
	}
}
