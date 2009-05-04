using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class EqualsNumericEvaluations : ContextSpecification
	{
		protected int _myNumber = 42;
		protected bool _actionWasPerformed;
	}

	[TestFixture]
	[Concern("Equals Evaluations")]
	public class when_number_is_equal_to_other_number : EqualsNumericEvaluations
	{
		protected override void Context()
		{
			When.This(_myNumber).EqualsThis(42)
				.DoThis(() => _actionWasPerformed = true).Evaluate();
		}

		[Test]
		[Observation]
		public void should_perform_action()
		{
			_actionWasPerformed.ShouldBeTrue();
		}
	}

	[TestFixture]
	[Concern("Equals Evaluations")]
	public class when_number_is_not_equal_to_other_number : EqualsNumericEvaluations
	{
		protected override void Context()
		{
			When.This(_myNumber).EqualsThis(11)
				.DoThis(() => _actionWasPerformed = true).Evaluate();
		}

		[Test]
		[Observation]
		public void should_not_perform_action()
		{
			_actionWasPerformed.ShouldBeFalse();
		}
	}
}