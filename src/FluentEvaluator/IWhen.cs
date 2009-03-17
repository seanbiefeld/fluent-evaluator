namespace FluentEvaluator
{
	public interface IWhen
	{
		Evaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate);

		EvaluationAction This(bool boolToEvaluate);
	}
}
