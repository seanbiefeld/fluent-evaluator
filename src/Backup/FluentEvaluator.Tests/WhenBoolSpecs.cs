﻿using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class WhenBoolSpecs : ContextSpecification
	{
		protected int _myNumber = 11;
	}

	[TestFixture]
	[Concern("when(bool)")]
	public class when_passing_in_true : WhenBoolSpecs
	{
		protected override void Context()
		{
			When.This(true).DoThis(() => _myNumber++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_make_my_number_equal_twelve()
		{
			_myNumber.ShouldEqual(12);
		}
	}

	[TestFixture]
	[Concern("when(bool)")]
	public class when_passing_in_false : WhenBoolSpecs
	{
		protected override void Context()
		{
			When.This(false).DoThis(() => _myNumber++).Evaluate();
		}

		[Test]
		[Observation]
		public void should_leave_my_number_as_eleven()
		{
			_myNumber.ShouldEqual(11);
		}
	}
}
