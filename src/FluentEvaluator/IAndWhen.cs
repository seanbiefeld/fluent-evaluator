namespace FluentEvaluator
{
	public interface IAndWhen : IWhen
	{
		AndEvaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate);
	}
}