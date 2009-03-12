using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class WhenBoolSpecs : ContextSpecification
	{
	}

	[TestFixture]
	[Concern("when(bool)")]
	public class when_passing_in_true : ContextSpecification
	{
		private int _myNumber = 11;

		protected override void Context()
		{
			When.This(true).DoThis(() => _myNumber++).Engage();
		}

		[Test]
		[Observation]
		public void should_make_my_number_equal_twelve()
		{
			_myNumber.ShouldEqual(12);
		}
	}

	[TestFixture]
	[Concern("when(bool)")]
	public class when_passing_in_false: ContextSpecification
	{
		private int _myNumber = 11;

		protected override void Context()
		{
			When.This(false).DoThis(() => _myNumber++).Engage();
		}

		[Test]
		[Observation]
		public void should_leave_my_number_as_eleven()
		{
			_myNumber.ShouldEqual(11);
		}
	}
}
