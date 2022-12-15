using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Xacte.Common.RAMQ;

namespace Xacte.Common.TestExtension;

public static class StringAssertionExtensions
{
	public static AndConstraint<StringAssertions> BeSystemNumeroAssuranceMaladie(
		this StringAssertions parent,
		string because = "",
		params object[] becauseArgs)
	{
		Execute.Assertion
			.BecauseOf(because, becauseArgs)
			.Given(() => parent.Subject)
			.ForCondition(NumeroAssuranceMaladie.IsSystemNAM)
			.FailWith($"Expected any system NAM, but found '{parent.Subject}'");

		return new AndConstraint<StringAssertions>(parent);
	}
}

