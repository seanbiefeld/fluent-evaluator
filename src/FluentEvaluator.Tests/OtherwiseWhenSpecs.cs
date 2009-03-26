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
	public class when_otherwise_when : OtherwiseWhenSpecs
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
		public void count_should_equal_four()
		{
			count.ShouldEqual(4);
		}
	}

}