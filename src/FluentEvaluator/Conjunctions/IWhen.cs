using FluentEvaluator.Actions;
using FluentEvaluator.Evaluations;

namespace FluentEvaluator.Conjunctions
{
	public interface IWhen
	{
		IEvaluationAction This(bool boolToEvaluate);
	}

	public interface ISingularWhen : IWhen
	{
		IEvaluation<SingularAction<TypeToEvaluate>, TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate);
	}
}