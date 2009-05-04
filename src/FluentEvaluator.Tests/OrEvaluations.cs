using System.Collections.Generic;
using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class OrEvaluations : ContextSpecification
	{
		protected TestableFoo _testableFoo;
		protected string _testableString;
		protected List<object> _testableList;
		protected int _count = 1;
	}

	#region or null evaluations

	[TestFixture]
	[Concern("or null evaluation")]
	public class when_using_an_or_evaluating_null_and_it_is_true : OrEvaluations
	{
		protected override void Context()
		{
			_testableString = null;
			_testableFoo = null;

			When.This(_testableFoo).IsNull.Or.When.This(_testableString).IsNull.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_make_count_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("or null evaluation")]
	public class when_using_an_or_evaluating_null_and_it_is_false : OrEvaluations
	{
		protected override void Context()
		{
			_testableString = "asdf";
			_testableFoo = new TestableFoo();

			When.This(_testableFoo).IsNull.Or.When.This(_testableString).IsNull.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_leave_count_as_one()
		{
			_count.ShouldEqual(1);
		}
	}

	#endregion

	#region or empty evaluations

	[TestFixture]
	[Concern("or empty evaluations")]
	public class when_using_an_or_expression_and_checking_is_empty_when_not_empty : OrEvaluations
	{
		protected override void Context()
		{
			_testableString = "asdf";
			_testableList = new List<object> { new object() };

			When.This(_testableString).IsEmpty.Or.When.This(_testableList).IsEmpty.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void count_should_equal_one()
		{
			_count.ShouldEqual(1);
		}
	}

	[TestFixture]
	[Concern("or empty evaluations")]
	public class when_using_an_or_expression_and_checking_is_empty_and_is_empty : OrEvaluations
	{
		protected override void Context()
		{
			_testableString = string.Empty;
			_testableList = new List<object>();

			When.This(_testableString).IsEmpty.Or.When.This(_testableList).IsEmpty.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void count_should_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	#endregion

	#region equal evaluations

	[TestFixture]
	[Concern("or equal evaluations")]
	public class when_using_an_or_expression_and_checking_equals_and_it_does_equal : OrEvaluations
	{
		private string stringToCompare = "foo";

		protected override void Context()
		{
			When.This(stringToCompare).EqualsThis("foo").Or.When.This(stringToCompare).EqualsThis(string.Empty).DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void count_should_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("or equal evaluations")]
	public class when_using_an_or_expression_and_checking_equals_and_it_doesnt_equal : OrEvaluations
	{
		protected override void Context()
		{
			When.This(1).EqualsThis(3).Or.When.This(2).EqualsThis(5).DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void count_should_equal_one()
		{
			_count.ShouldEqual(1);
		}
	}

	#endregion
}