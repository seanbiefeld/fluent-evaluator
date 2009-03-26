namespace FluentEvaluator
{
	public interface IOrWhen : IWhen
	{
		OrEvaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate);
	}
}