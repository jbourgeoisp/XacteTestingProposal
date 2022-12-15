using System.Text.Json.Serialization;

namespace Xacte.Common;
public class CallResultWithData<T> : CallResult
{
	public CallResultWithData()
	{

	}

	public CallResultWithData(T data)
	{
		if (data != null)
			Success = true;

		Data = data;
	}

	public CallResultWithData(string errorMessage)
	{
		ErrorMessage = errorMessage;
	}


	[JsonPropertyName("Data")]
	public T Data { get; set; }
}
