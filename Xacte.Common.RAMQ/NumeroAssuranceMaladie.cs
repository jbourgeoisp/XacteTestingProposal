namespace Xacte.Common.RAMQ;

public class NumeroAssuranceMaladie
{
	public static string XXXX => "XXXX01010112";
	public static string ZZZZ => "ZZZZ01010112";

	public static bool IsSystemNAM(string nam)
	{
		if (string.IsNullOrEmpty(nam))
			return false;

		return IsZZZZ(nam) || IsXXXX(nam);
	}

	public static bool IsZZZZ(string nam)
	{
		if (string.IsNullOrEmpty(nam))
			return false;

		return nam == ZZZZ;
	}

	public static bool IsXXXX(string nam)
	{
		if (string.IsNullOrEmpty(nam))
			return false;

		return nam == XXXX;
	}
}
