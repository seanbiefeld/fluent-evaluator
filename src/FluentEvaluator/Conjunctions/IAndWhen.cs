using FluentEvaluator.Evaluations;

namespace FluentEvaluator.Conjunctions
{
	public interface IAndWhen : IWhen
	{
		AndEvaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate);
	}
}