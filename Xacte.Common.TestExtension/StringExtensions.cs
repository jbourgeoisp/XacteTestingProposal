using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace Xacte.Common.TestExtension;

public static class StringAssertionExtensions
{
	private static string[] _systemNumeroAssuranceMaladie =
	{
		"ZZZZ01010112",
		"XXXX01010112"
	};

	public static AndConstraint<StringAssertions> BeSystemNumeroAssuranceMaladie(
		this StringAssertions parent,
		string because = "",
		params object[] becauseArgs)
	{
		Execute.Assertion
			.BecauseOf(because, becauseArgs)
			.Given(() => parent.Subject)
			.ForCondition(s => _systemNumeroAssuranceMaladie.Contains(s))
			.FailWith($"Expected any system NAM, but found '{parent.Subject}'");

		return new AndConstraint<StringAssertions>(parent);
	}
}

