using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class GreaterThanNumericEvaluations : ContextSpecification
	{
		protected int _myNumber = 42;
		protected bool _actionWasPerformed;
	}

	[TestFixture]
	[Concern("Greater Than Evaluations")]
	public class when_number_is_greater_than_other_number : GreaterThanNumericEvaluations
	{
		protected override void Context()
		{
			When.This(_myNumber).IsGreaterThan(11)
				.DoThis(()=>_actionWasPerformed = true).Evaluate();
		}

		[Test]
		[Observation]
		public void should_perform_action()
		{
			_actionWasPerformed.ShouldBeTrue();
		}
	}

	[TestFixture]
	[Concern("Greater Than Evaluations")]
	public class when_number_is_not_greater_than_other_number : GreaterThanNumericEvaluations
	{
		protected override void Context()
		{
			When.This(_myNumber).IsGreaterThan(52)
				.DoThis(() => _actionWasPerformed = true).Evaluate();
		}

		[Test]
		[Observation]
		public void should_not_perform_action()
		{
			_actionWasPerformed.ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("Greater Than Evaluations")]
	public class when_number_is_equal_to_other_number_checking_greater_than : GreaterThanNumericEvaluations
	{
		protected override void Context()
		{
			When.This(_myNumber).IsGreaterThan(_myNumber)
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