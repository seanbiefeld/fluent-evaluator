using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class EvaluationUtilitiesSpecs : ContextSpecification
	{
		protected IList _testableList;
		protected ICollection _testableCollection;
		protected object[] _testableArray;
		protected string _testableString;
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_a_null_object : ContextSpecification
	{
		[Test]
		[Observation]
		public void should_be_false()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(null)).ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_a_non_applicable_type : ContextSpecification
	{
		[Test]
		[Observation]
		public void should_be_false()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(32)).ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_an_empty_IList : EvaluationUtilitiesSpecs
	{
		protected override void Context()
		{
			_testableList = new List<object>();
		}

		[Test]
		[Observation]
		public void should_be_true()
		{
            (EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(_testableList)).ShouldBeTrue();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_a_non_empty_IList : EvaluationUtilitiesSpecs
	{
		protected override void Context()
		{
			_testableList = new List<object>{new object()};
		}

		[Test]
		[Observation]
		public void should_be_false()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(_testableList)).ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_a_null_IList : EvaluationUtilitiesSpecs
	{
		[Test]
		[Observation]
		public void should_be_false()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(_testableList)).ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_an_empty_ICollection : EvaluationUtilitiesSpecs
	{
		protected override void Context()
		{
			_testableCollection = new Collection<object>();
		}

		[Test]
		[Observation]
		public void should_be_true()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(_testableCollection)).ShouldBeTrue();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_a_non_empty_collection : EvaluationUtilitiesSpecs
	{
		protected override void Context()
		{
			_testableCollection = new Collection<object>{new object()};
		}

		[Test]
		[Observation]
		public void should_be_false()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(_testableCollection)).ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_a_null_ICollection : EvaluationUtilitiesSpecs
	{
		[Test]
		[Observation]
		public void should_be_false()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(_testableCollection)).ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_an_empty_array : EvaluationUtilitiesSpecs
	{
		protected override void Context()
		{
			_testableArray = new object[0];
		}

		[Test]
		[Observation]
		public void should_be_true()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(_testableArray)).ShouldBeTrue();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_a_non_empty_array : EvaluationUtilitiesSpecs
	{
		protected override void Context()
		{
			_testableArray = new[] { new object() };
		}

		[Test]
		[Observation]
		public void should_be_false()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(_testableArray)).ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_a_null_array : EvaluationUtilitiesSpecs
	{
		[Test]
		[Observation]
		public void should_be_false()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(_testableArray)).ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_an_empty_string : EvaluationUtilitiesSpecs
	{
		protected override void Context()
		{
			_testableString = string.Empty;
		}

		[Test]
		[Observation]
		public void should_be_true()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(_testableString)).ShouldBeTrue();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_a_non_empty_string : EvaluationUtilitiesSpecs
	{
		protected override void Context()
		{
			_testableString = "asdf";
		}

		[Test]
		[Observation]
		public void should_be_false()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(_testableString)).ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("is empty evaluation")]
	public class when_evaluating_a_null_string : EvaluationUtilitiesSpecs
	{
		[Test]
		[Observation]
		public void should_be_false()
		{
			(EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(_testableString)).ShouldBeFalse();
		}
	}

	[TestFixture]
	[Concern("validating predicate")]
	public class when_the_predicate_is_invalid : ContextSpecification
	{
		[Test]
		[Observation]
		[ExpectedException(typeof(Exception))]
		public void should_throw_an_error()
		{
			EvaluationUtilities.EnsurePredicateIsValid<object>(null);
		}
	}
}