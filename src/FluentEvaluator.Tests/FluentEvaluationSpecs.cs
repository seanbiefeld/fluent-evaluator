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

	public class TestableException : Exception{}

	public class FluentEvalutionSpecs : ContextSpecification
	{
		protected TestableFoo _testableFooToTest;
		protected string _testableString;
	}

	#region when is null creation specs

	[TestFixture]
	[Concern("Fluent Evaluator")]
	public class when_creating_on_null : FluentEvalutionSpecs
	{
		protected override void Context()
		{
			_testableFooToTest = null;

			_testableFooToTest = _testableFooToTest.When<TestableFoo>().IsNull().Create();
		}

		[Test]
		[Observation]
		public void should_be_a_new_instance()
		{
			Assert.IsNotNull(_testableFooToTest);
		}
	}

	[TestFixture]
	[Concern("Fluent Evaluator")]
	public class when_creating_on_non_null : FluentEvalutionSpecs
	{
		protected TestableFoo newFoo;

		protected override void Context()
		{
			_testableFooToTest = new TestableFoo();

			newFoo = _testableFooToTest.When<TestableFoo>().IsNull().Create();
		}

		[Test]
		[Observation]
		public void should_be_be_equal()
		{
			Assert.AreEqual(_testableFooToTest, newFoo);
		}
	}

	[TestFixture]
	[Concern("Fluent Evaluator")]
	public class when_creating_on_null_with_args : FluentEvalutionSpecs
	{
		private int _intArg = 42;
		private string _stringArg = "asdf";

		protected override void Context()
		{
			_testableFooToTest = null;

			_testableFooToTest = _testableFooToTest.When<TestableFoo>().IsNull().Create(_stringArg, _intArg);
		}

		[Test]
		[Observation]
		public void should_be_a_new_instance()
		{
			Assert.IsNotNull(_testableFooToTest);
		}

		[Test]
		[Observation]
		public void args_should_match()
		{
			Assert.AreEqual(_stringArg, _testableFooToTest.FooString);
			Assert.AreEqual(_intArg, _testableFooToTest.FooInt);
		}
	}

	[TestFixture]
	[Concern("Fluent Evaluator")]
	public class when_creating_on_non_null_with_args : FluentEvalutionSpecs
	{
		private int _intArg = 42;
		private string _stringArg = "asdf";

		protected override void Context()
		{
			_testableFooToTest = new TestableFoo(_stringArg, _intArg);

			_testableFooToTest = _testableFooToTest.When<TestableFoo>().IsNull().Create(_stringArg, _intArg);
		}

		[Test]
		[Observation]
		public void args_should_match()
		{
			Assert.AreEqual(_stringArg, _testableFooToTest.FooString);
			Assert.AreEqual(_intArg, _testableFooToTest.FooInt);
		}
	}

	[TestFixture]
	[Concern("Fluent Evaluator")]
	public class when_creating_on_non_class_with_null : FluentEvalutionSpecs
	{
		protected override void Context()
		{
			_testableString = null;

			_testableString = _testableString.When<string>().IsNull().Create();
		}

		[Test]
		[Observation]
		public void should_be_the_default()
		{
			Assert.AreEqual(default(string), _testableString);
		}
	}

	[TestFixture]
	[Concern("Fluent Evaluator")]
	public class when_creating_on_non_class_with_non_null : FluentEvalutionSpecs
	{
		protected override void Context()
		{
			_testableString = "asdf";

			_testableString = _testableString.When<string>().IsNull().Create();
		}

		[Test]
		[Observation]
		public void should_not_affect_the_value()
		{
			Assert.AreEqual("asdf", _testableString);
		}
	}

	#endregion

	[TestFixture]
	[Concern("Fluent Evaluation")]
	public class when_is_null_and_throws_an_excepiton : FluentEvalutionSpecs
	{
		[Test]
		[Observation]
		[ExpectedException(typeof(TestableException))]
		public void should_throw_specified_exceptionType()
		{
			_testableFooToTest = null;

			_testableFooToTest.When<TestableFoo>().IsNull().ThrowException<TestableException>();
		}
	}
}