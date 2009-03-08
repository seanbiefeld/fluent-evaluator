using System;

namespace FluentEvaluator
{
	public interface IFluentEvaluation<TypeToPerformEvaluationOn>
	{
		FluentEvaluation<TypeToPerformEvaluationOn> IsNull();

		TypeToPerformEvaluationOn Create(params object[] arguments);

		void ThrowException<ExceptionType>(params object[] exceptionArguments) where ExceptionType : Exception;
	}
}