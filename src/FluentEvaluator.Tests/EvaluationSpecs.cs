using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class EvaluationSpecs : ContextSpecification
	{
	}

	[TestFixture]
	[Concern("EqualsThis evaluation")]
	public class when_objects_equal : ContextSpecification
	{
		protected TestableFoo _testableFooOne;
		protected TestableFoo _testableFooTwo;
		protected int _count = 1;

		protected override void Context()
		{
			_testableFooOne = new TestableFoo();
			_testableFooTwo = _testableFooOne;

			When.This(_testableFooOne).EqualsThis(_testableFooTwo).DoThis(() => _count++);
		}

		[Test]
		[Observation]
		public void count_should_equal_two()
		{
			_count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("EqualsThis evaluation")]
	public class when_objects_dont_equal : ContextSpecification
	{
		protected TestableFoo _testableFooOne;
		protected TestableFoo _testableFooTwo;
		protected int _count = 1;

		protected override void Context()
		{
			_testableFooOne = new TestableFoo();
			_testableFooTwo = new TestableFoo();

			When.This(_testableFooOne).EqualsThis(_testableFooTwo).DoThis(() => _count++);
		}

		[Test]
		[Observation]
		public void count_should_equal_one()
		{
			_count.ShouldEqual(1);
		}
	}
}
