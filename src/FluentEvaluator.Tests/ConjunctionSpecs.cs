using System.Collections.Generic;
using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class ConjunctionSpecs : ContextSpecification
	{
		protected TestableFoo _testableFoo;
		protected string _testableString;
		protected List<object> _testableList;
	}

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_and_expression_and_it_is_true : ConjunctionSpecs
	{
		private int _count = 1;
		protected override void Context()
		{
			_testableString = null;
			_testableFoo = null;

			When.This(_testableFoo).IsNull.AndWhenThis(_testableString).IsNull.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_make_count_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_and_expression_and_it_is_false : ConjunctionSpecs
	{
		private int _count = 1;
		protected override void Context()
		{
			_testableString = null;
			_testableFoo = new TestableFoo();

			When.This(_testableFoo).IsNull
				.AndWhenThis(_testableString).IsNull
				.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_leave_count_as_one()
		{
			_count.ShouldEqual(1);
		}
	}

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_or_expression_and_both_are_true : ConjunctionSpecs
	{
		private int _count = 1;
		protected override void Context()
		{
			_testableString = null;
			_testableFoo = null;

			When.This(_testableFoo).IsNull.OrWhenThis(_testableString).IsNull.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_make_count_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_or_expression_and_one_is_true : ConjunctionSpecs
	{
		private int _count = 1;
		protected override void Context()
		{
			_testableString = null;
			_testableFoo = new TestableFoo();

			When.This(_testableFoo).IsNull.OrWhenThis(_testableString).IsNull.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_make_count_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_or_expression_and_both_are_false : ConjunctionSpecs
	{
		private int _count = 1;
		protected override void Context()
		{
			_testableString = "asdf";
			_testableFoo = new TestableFoo();

			When.This(_testableFoo).IsNull.OrWhenThis(_testableString).IsNull.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_leave_count_as_one()
		{
			_count.ShouldEqual(1);
		}
	}

	#region conjunction is empty specs

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_and_expression_and_checking_is_empty_when_not_empty : ConjunctionSpecs
	{
		protected int _count = 1;
		protected override void Context()
		{
			_testableString = "asdf";
			_testableList = new List<object>{new object()};

			When.This(_testableString).IsEmpty.AndWhenThis(_testableList).IsEmpty.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void count_should_equal_one()
		{
			_count.ShouldEqual(1);
		}
	}

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_and_expression_and_checking_is_empty_and_is_empty : ConjunctionSpecs
	{
		protected int _count = 1;
		protected override void Context()
		{
			_testableString = string.Empty;
			_testableList = new List<object>();

			When.This(_testableString).IsEmpty.AndWhenThis(_testableList).IsEmpty.DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void count_should_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_or_expression_and_checking_is_empty_when_not_empty : when_using_an_and_expression_and_checking_is_empty_when_not_empty
	{
		protected override void Context()
		{
			_testableString = "asdf";
			_testableList = new List<object> { new object() };

			When.This(_testableString).IsEmpty.OrWhenThis(_testableList).IsEmpty.DoThis(() => _count++).Evaluate();
		}
	}

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_or_expression_and_checking_is_empty_and_is_empty : when_using_an_and_expression_and_checking_is_empty_and_is_empty
	{
		protected override void Context()
		{
			_testableString = string.Empty;
			_testableList = new List<object>();

			When.This(_testableString).IsEmpty.OrWhenThis(_testableList).IsEmpty.DoThis(() => _count++).Evaluate();
		}
	}


	#endregion

	#region conjunction equal specs

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_and_expression_and_checking_equals_and_it_does_equal : ConjunctionSpecs
	{
		protected int _count = 1;
		protected override void Context()
		{
			When.This(1).EqualsThis(1).AndWhenThis(2).EqualsThis(2).DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void count_should_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_and_expression_and_checking_equals_and_it_doesnt_equal : ConjunctionSpecs
	{
		protected int _count = 1;
		protected override void Context()
		{
			When.This(1).EqualsThis(3).AndWhenThis(2).EqualsThis(5).DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void count_should_equal_one()
		{
			_count.ShouldEqual(1);
		}
	}

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_or_expression_and_checking_equals_and_it_does_equal : ConjunctionSpecs
	{
		protected int _count = 1;
		protected override void Context()
		{
			When.This(1).EqualsThis(1).OrWhenThis(3).EqualsThis(2).DoThis(() => _count++).Evaluate();
		}

		[Test]
		[Observation]
		public void count_should_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("and when action")]
	public class when_using_an_or_expression_and_checking_equals_and_it_doesnt_equal : ConjunctionSpecs
	{
		protected int _count = 1;
		protected override void Context()
		{
			When.This(1).EqualsThis(3).OrWhenThis(2).EqualsThis(5).DoThis(() => _count++).Evaluate();
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