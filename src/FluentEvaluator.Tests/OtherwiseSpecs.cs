using System;
using FluentEvaluator.Conjunctions;
using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class OtherwiseSpecs : ContextSpecification
	{
		protected TestableFoo _foo;
		protected int _myNumber = 42;
	}

	[TestFixture]
	[Concern("otherwise")]
	public class when_using_otherwise_action : OtherwiseSpecs
	{
		protected override void Context()
		{
			When.This(_foo).IsNotNull.DoThis(() => _myNumber++)
				.Otherwise.DoThis(() => _myNumber--).Evaluate();
		}

		[Test]
		[Observation]
		public void should_make_my_number_forty_one()
		{
			_myNumber.ShouldEqual(41);
		}
	}

	[TestFixture]
	[Concern("otherwise")]
	public class when_throwing_an_exception : OtherwiseSpecs
	{
        [Test]
		[Observation]
		[ExpectedException(typeof(ApplicationException))]
		public void should_throw_application_exception()
		{
			When.This(_foo).IsNotNull.DoThis(() => _myNumber++)
				.Otherwise.ThrowAnException<ApplicationException>().Evaluate();
		}
	}
}