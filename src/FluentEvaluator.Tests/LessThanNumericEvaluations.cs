using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class LessThanNumericEvaluations : ContextSpecification
	{
		protected int _myNumber = 42;
		protected bool _actionWasPerformed;
	}

	[TestFixture]
	[Concern("Less Than Evaluations")]
	public class when_number_is_less_than_other_number : LessThanNumericEvaluations
	{
		protected override void Context()
		{
			When.This(_myNumber).IsLessThan(41)
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
	[Concern("Less Than Evaluations")]
	public class when_number_is_not_less_than_other_number : LessThanNumericEvaluations
	{
		protected override void Context()
		{
			When.This(_myNumber).IsLessThan(43)
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
	[Concern("Less Than Evaluations")]
	public class when_number_is_equal_to_other_number_checking_less_than : LessThanNumericEvaluations
	{
		protected override void Context()
		{
			When.This(_myNumber).IsLessThan(_myNumber)
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
