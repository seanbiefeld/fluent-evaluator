using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class SingularActions
	{
	}

	#region when is null creation specs

	[TestFixture]
	[Concern("Fluent Evaluator")]
	public class when_creating_on_null : EvaluationActionsSpecs
	{
		protected override void Context()
		{
			_testableFoo = null;

			_testableFoo = When.This(_testableFoo).IsNull.CreateIt();
		}

		[Test]
		[Observation]
		public void should_be_a_new_instance()
		{
			_testableFoo.ShouldNotBeNull();
		}
	}

	[TestFixture]
	[Concern("Fluent Evaluator")]
	public class when_creating_on_non_null : EvaluationActionsSpecs
	{
		protected TestableFoo newFoo;

		protected override void Context()
		{
			_testableFoo = new TestableFoo();

			newFoo = When.This(_testableFoo).IsNull.CreateIt();
		}

		[Test]
		[Observation]
		public void should_be_be_equal()
		{
			Assert.AreEqual(_testableFoo, newFoo);
		}
	}

	[TestFixture]
	[Concern("Fluent Evaluator")]
	public class when_creating_on_null_with_args : EvaluationActionsSpecs
	{
		private int _intArg = 42;
		private string _stringArg = "asdf";

		protected override void Context()
		{
			_testableFoo = null;

			_testableFoo = When.This(_testableFoo).IsNull.CreateIt(_stringArg, _intArg);
		}

		[Test]
		[Observation]
		public void should_be_a_new_instance()
		{
			Assert.IsNotNull(_testableFoo);
		}

		[Test]
		[Observation]
		public void args_should_match()
		{
			Assert.AreEqual(_stringArg, _testableFoo.FooString);
			Assert.AreEqual(_intArg, _testableFoo.FooInt);
		}
	}

	[TestFixture]
	[Concern("Fluent Evaluator")]
	public class when_creating_on_non_null_with_args : EvaluationActionsSpecs
	{
		private int _intArg = 42;
		private string _stringArg = "asdf";

		protected override void Context()
		{
			_testableFoo = new TestableFoo(_stringArg, _intArg);

			_testableFoo = When.This(_testableFoo).IsNull.CreateIt(_stringArg, _intArg);
		}

		[Test]
		[Observation]
		public void args_should_match()
		{
			Assert.AreEqual(_stringArg, _testableFoo.FooString);
			Assert.AreEqual(_intArg, _testableFoo.FooInt);
		}
	}

	[TestFixture]
	[Concern("Fluent Evaluator")]
	public class when_creating_on_non_class_with_null : EvaluationActionsSpecs
	{
		protected override void Context()
		{
			_testableString = null;

			_testableString = When.This(_testableString).IsNull.CreateIt();
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
	public class when_creating_on_non_class_with_non_null : EvaluationActionsSpecs
	{
		protected override void Context()
		{
			_testableString = "asdf";

			_testableString = When.This(_testableString).IsNull.CreateIt();
		}

		[Test]
		[Observation]
		public void should_not_affect_the_value()
		{
			Assert.AreEqual("asdf", _testableString);
		}
	}

	#endregion
}