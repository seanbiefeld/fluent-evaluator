using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class IsNotEmptyEvaluation : ContextSpecification
	{
		protected string _stringToEvaluate;
		protected ICollection _collectionToEvaluate;
		protected bool _actionWasPerformed;
	}

	[TestFixture]
	[Concern("Is Not Empty ObjectEvaluation")]
	public class when_evaluating_if_an_non_empty_string_is_not_empty : IsNotEmptyEvaluation
	{
		protected override void Context()
		{
			_stringToEvaluate = "jumanji";

			When.This(_stringToEvaluate).IsNotEmpty
				.DoThis(() => _actionWasPerformed = true).Evaluate();
		}

		[Test]
		[Observation]
		public void should_perfrom_the_action()
		{
			_actionWasPerformed.ShouldBeTrue();
		}
	}

	[TestFixture]
	[Concern("Is Not Empty ObjectEvaluation")]
	public class when_evaluating_if_an_empty_string_is_not_empty : IsNotEmptyEvaluation
	{
		protected override void Context()
		{
			_stringToEvaluate = string.Empty;

			When.This(_stringToEvaluate).IsNotEmpty
				.DoThis(() => _actionWasPerformed = true).Evaluate();
		}

		[Test]
		[Observation]
		public void should_not_perfrom_the_action()
		{
			_actionWasPerformed.ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("Is Not Empty ObjectEvaluation")]
	public class when_evaluating_if_an_non_empty_collection_is_not_empty : IsNotEmptyEvaluation
	{
		protected override void Context()
		{
			_collectionToEvaluate = new List<string>{"futurama"};

			When.This(_collectionToEvaluate).IsNotEmpty
				.DoThis(() => _actionWasPerformed = true).Evaluate();
		}

		[Test]
		[Observation]
		public void should_perfrom_the_action()
		{
			_actionWasPerformed.ShouldBeTrue();
		}
	}

	[TestFixture]
	[Concern("Is Not Empty ObjectEvaluation")]
	public class when_evaluating_if_an_empty_collection_is_not_empty : IsNotEmptyEvaluation
	{
		protected override void Context()
		{
			_collectionToEvaluate = new List<string>();

			When.This(_collectionToEvaluate).IsNotEmpty
				.DoThis(() => _actionWasPerformed = true).Evaluate();
		}

		[Test]
		[Observation]
		public void should_not_perfrom_the_action()
		{
			_actionWasPerformed.ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("Is Not Empty ObjectEvaluation")]
	public class when_evaluating_if_a_null_is_not_empty : IsNotEmptyEvaluation
	{
		protected override void Context()
		{
			_collectionToEvaluate = null;

			When.This(_collectionToEvaluate).IsNotEmpty
				.DoThis(() => _actionWasPerformed = true).Evaluate();
		}

		[Test]
		[Observation]
		public void should_not_perfrom_the_action()
		{
			_actionWasPerformed.ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("Is Not Empty ObjectEvaluation")]
	public class when_evaluating_if_a_non_collection_or_non_string_is_not_empty : IsNotEmptyEvaluation
	{
		protected override void Context()
		{
			When.This(new TestableFoo()).IsNotEmpty
				.DoThis(() => _actionWasPerformed = true).Evaluate();
		}

		[Test]
		[Observation]
		public void should_not_perfrom_the_action()
		{
			_actionWasPerformed.ShouldBeFalse();
		}
	}
}