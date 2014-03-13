using System;
using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class TestableFoo
	{
		public TestableFoo()
		{
		}

		public TestableFoo(string fooString, int fooInt)
		{
			FooInt = fooInt;
			FooString = fooString;
		}

		public string FooString
		{
			get;
			set;
		}

		public int FooInt
		{
			get;
			set;
		}
	}

	public class TestableException : Exception
	{
	}

	public class EvaluationActionsSpecs : ContextSpecification
	{
		protected TestableFoo _testableFoo;
		protected string _testableString;
	}

	[TestFixture]
	[Concern("Fluent ObjectEvaluation")]
	public class when_throws_an_excepiton : EvaluationActionsSpecs
	{
		[Test]
		[Observation]
		[ExpectedException(typeof(TestableException))]
		public void should_throw_specified_exceptionType()
		{
			_testableFoo = null;

			When.This(_testableFoo).IsNull.ThrowAnException<TestableException>().Evaluate();
		}
	}

	[TestFixture]
	[Concern("Do this custom action")]
	public class when_performing_a_custom_action : EvaluationActionsSpecs
	{
		private int _counter = 42;

		protected override void Context()
		{
			_testableFoo = null;
			When.This(_testableFoo).IsNull.DoThis(() => _counter++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_add_one_to_counter()
		{
			_counter.ShouldEqual(43);
		}
	}
}