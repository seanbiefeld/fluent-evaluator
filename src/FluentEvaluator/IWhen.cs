namespace FluentEvaluator
{
	public interface IWhen
	{
		IEvaluationAction This(bool boolToEvaluate);
	}

	public interface ISingularWhen : IWhen
	{
		IEvaluation<SingularAction<TypeToEvaluate>, TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate);
	}

	public interface IAndWhen : IWhen
	{
		AndEvaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate);
	}

	public interface IOrWhen : IWhen
	{
		OrEvaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate);
	}
}
