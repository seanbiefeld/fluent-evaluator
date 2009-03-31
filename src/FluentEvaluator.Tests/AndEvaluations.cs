using System.Collections.Generic;
using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class AndEvaluations : ContextSpecification
	{
		protected TestableFoo _testableFoo;
		protected string _testableString;
		protected List<object> _testableList;
		protected int _count = 1;
	}

	#region null evaluations

	[TestFixture]
	[Concern("and null evaluation")]
	public class when_using_an_and_evaluating_null_and_it_is_true : AndEvaluations
	{
		protected override void Context()
		{
			_testableString = null;
			_testableFoo = null;

			When.This(_testableFoo).IsNull
				.And.When.This(_testableString).IsNull
				.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_make_count_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("and null evaluation")]
	public class when_using_an_and_evaluating_null_and_it_is_false : AndEvaluations
	{
		protected override void Context()
		{
			_testableString = null;
			_testableFoo = new TestableFoo();

			When.This(_testableFoo).IsNull
				.And.When.This(_testableString).IsNull
				.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_leave_count_as_one()
		{
			_count.ShouldEqual(1);
		}
	}

	#endregion

	#region empty evaluations

	[TestFixture]
	[Concern("and empty evaluations")]
	public class when_using_an_and_expression_and_checking_is_empty_when_not_empty : AndEvaluations
	{
		protected override void Context()
		{
			_testableString = "asdf";
			_testableList = new List<object> { new object() };

			When.This(_testableString).IsEmpty.And.When.This(_testableList).IsEmpty.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void count_should_equal_one()
		{
			_count.ShouldEqual(1);
		}
	}

	[TestFixture]
	[Concern("and empty evaluations")]
	public class when_using_an_and_expression_and_checking_is_empty_and_is_empty : AndEvaluations
	{
		
		protected override void Context()
		{
			_testableString = string.Empty;
			_testableList = new List<object>();

			When.This(_testableString).IsEmpty.And.When.This(_testableList).IsEmpty.DoThis(() => _count++).Evaluate();
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
	[Concern("and equal evaluations")]
	public class when_using_an_and_expression_and_checking_equals_and_it_does_equal : AndEvaluations
	{
		protected override void Context()
		{
			When.This(1).EqualsThis(1).And.When.This(2).EqualsThis(2).DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void count_should_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("and equal evaluations")]
	public class when_using_an_and_expression_and_checking_equals_and_it_doesnt_equal : AndEvaluations
	{
		protected override void Context()
		{
			When.This(1).EqualsThis(3).And.When.This(2).EqualsThis(5).DoThis(() => _count++).Evaluate();
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