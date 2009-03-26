using System;

namespace FluentEvaluator
{
	public interface IEvaluationAction
	{
		EvaluationConclusion ThrowAnException<ExceptionType>(params object[] exceptionArguments)
			where ExceptionType : Exception;


		EvaluationConclusion DoThis(Action actionToPerform);
		
	}
}