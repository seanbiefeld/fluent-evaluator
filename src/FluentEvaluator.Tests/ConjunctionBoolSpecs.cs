using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class ConjunctionBoolSpecs : ContextSpecification
	{
		protected int _myNumber = 13;
	}

	[TestFixture]
	[Concern("Or.When.This(bool)")]
	public class when_the_or_evaluates_to_true : ConjunctionBoolSpecs
	{
		protected override void Context()
		{
			When.This(false)
				.Or.When.This(true)
			.DoThis(() => _myNumber++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_make_my_number_fourteen()
		{
			_myNumber.ShouldEqual(14);
		}
	}

	[TestFixture]
	[Concern("Or.When.This(bool)")]
	public class when_the_or_evaluates_to_false : ConjunctionBoolSpecs
	{
		protected override void Context()
		{
			When.This(false)
				.Or.When.This(false)
			.DoThis(() => _myNumber++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_not_change_my_number()
		{
			_myNumber.ShouldEqual(13);
		}
	}

	[TestFixture]
	[Concern("And.When.This(bool)")]
	public class when_the_and_evaluates_to_true : ConjunctionBoolSpecs
	{
		protected override void Context()
		{
			When.This(true)
				.And.When.This(true)
			.DoThis(() => _myNumber++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_make_my_number_fourteen()
		{
			_myNumber.ShouldEqual(14);
		}
	}

	[TestFixture]
	[Concern("And.When.This(bool)")]
	public class when_the_and_evaluates_to_false : ConjunctionBoolSpecs
	{
		protected override void Context()
		{
			When.This(true)
				.And.When.This(false)
			.DoThis(() => _myNumber++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_not_change_my_number()
		{
			_myNumber.ShouldEqual(13);
		}
	}
}
