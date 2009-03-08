using System;

namespace FluentEvaluator
{
	public interface IEvaluationAction<TypeToPerformEvaluationOn>
	{
		TypeToPerformEvaluationOn Create(params object[] arguments);

		void ThrowException<ExceptionType>(params object[] exceptionArguments) where ExceptionType : Exception;
	}
}