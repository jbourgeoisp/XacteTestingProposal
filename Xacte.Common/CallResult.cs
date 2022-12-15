using System.Text.Json.Serialization;

namespace Xacte.Common;

public class CallResult
{
	public CallResult()
	{

	}

	public CallResult(bool res)
	{
		Success = res;
	}

	public CallResult(string errorMessage = null)
	{
		if (!string.IsNullOrEmpty(errorMessage))
		{
			ErrorMessage = errorMessage;
			Success = false;
		}
	}

	[JsonPropertyName("Success")]
	public bool Success { get; set; }

	[JsonPropertyName("ResultData")]
	public string ResultData { get; set; }

	[JsonIgnore]
	[JsonPropertyName("ErrorMessage")]
	public string ErrorMessage { get; set; }
}
