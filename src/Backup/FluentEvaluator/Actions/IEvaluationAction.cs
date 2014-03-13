using System;
using FluentEvaluator.Conjunctions;

namespace FluentEvaluator.Actions
{
	public interface IEvaluationAction
	{
		EvaluationConclusion ThrowAnException<ExceptionType>(params object[] exceptionArguments)
			where ExceptionType : Exception;

		EvaluationConclusion DoThis(Action actionToPerform);

		And And{ get; }

		Or Or { get; }
	}
}