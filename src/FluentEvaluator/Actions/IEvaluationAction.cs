using System;

namespace FluentEvaluator.Actions
{
	public interface IEvaluationAction
	{
		EvaluationConclusion ThrowAnException<ExceptionType>(params object[] exceptionArguments)
			where ExceptionType : Exception;


		EvaluationConclusion DoThis(Action actionToPerform);
		
	}
}