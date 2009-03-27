using FluentEvaluator.Conjunctions;
using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class OtherwiseWhenSpecs : ContextSpecification
	{
		protected int count;
	}

	[TestFixture]
	[Concern("otherwise when")]
	public class when_there_are_multiple_trues : OtherwiseWhenSpecs
	{
		protected override void Context()
		{
			When.This(false).DoThis(()=>count = 1)
				.Otherwise.When.This(false).DoThis(()=>count =2)
				.Otherwise.When.This(false).DoThis(()=>count =3)
				.Otherwise.When.This(true).DoThis(()=>count = 4)
				.Otherwise.When.This(false).DoThis(()=>count = 5)
				.Otherwise.When.This(true).DoThis(()=>count = 6)
				.Otherwise.DoThis(()=>count = 7).Evaluate();
		}

		[Test]
		[Observation]
		public void the_first_one_should_be_evaluated()
		{
			count.ShouldEqual(4);
		}
	}

	[TestFixture]
	[Concern("otherwise when")]
	public class when_there_is_one_true : OtherwiseWhenSpecs
	{
		protected override void Context()
		{
			When.This(false).DoThis(() => count = 1)
				.Otherwise.When.This(false).DoThis(() => count = 2)
				.Otherwise.When.This(false).DoThis(() => count = 3)
				.Otherwise.When.This(false).DoThis(() => count = 4)
				.Otherwise.When.This(true).DoThis(() => count = 5)
				.Otherwise.When.This(false).DoThis(() => count = 6)
				.Otherwise.DoThis(() => count = 7).Evaluate();
		}

		[Test]
		[Observation]
		public void it_should_be_evaluated()
		{
			count.ShouldEqual(5);
		}
	}

	[TestFixture]
	[Concern("otherwise when")]
	public class when_there_is_a_single_otherwise_when : OtherwiseWhenSpecs
	{
		protected override void Context()
		{
			When.This(false).DoThis(() => count = 1)
				.Otherwise.When.This(true).DoThis(() => count = 2)
				.Otherwise.DoThis(() => count = 3).Evaluate();
		}

		[Test]
		[Observation]
		public void it_should_be_evaluated()
		{
			count.ShouldEqual(2);
		}
	}

	[TestFixture]
	[Concern("otherwise when")]
	public class when_none_are_true : OtherwiseWhenSpecs
	{
		protected override void Context()
		{
			When.This(false).DoThis(() => count = 1)
				.Otherwise.When.This(false).DoThis(() => count = 2)
				.Otherwise.When.This(false).DoThis(() => count = 3)
				.Otherwise.DoThis(() => count = 4).Evaluate();
		}

		[Test]
		[Observation]
		public void the_otherwise_should_be_evaluated()
		{
			count.ShouldEqual(4);
		}
	}

	[TestFixture]
	[Concern("otherwise when")]
	public class when_there_is_just_a_single_otherwise_when : OtherwiseWhenSpecs
	{
		protected override void Context()
		{
			When.This(false).DoThis(() => count = 1)
				.Otherwise.When.This(true).DoThis(() => count = 2);
		}

		[Test]
		[Observation]
		public void count_should_equal_()
		{
			count.ShouldEqual(2);
		}
	}
}