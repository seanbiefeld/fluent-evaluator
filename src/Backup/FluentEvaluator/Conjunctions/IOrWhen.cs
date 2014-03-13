using FluentEvaluator.Evaluations;

namespace FluentEvaluator.Conjunctions
{
	public interface IOrWhen : IWhen
	{
		OrEvaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate);
	}
}