namespace FluentEvaluator
{
	public class OtherwiseWhen : ISingularWhen
	{
		public IEvaluationAction This(bool boolToEvaluate)
		{
			return new EvaluationAction(boolToEvaluate, boolToEvaluate);
		}

		public IEvaluation<SingularAction<TypeToEvaluate>, TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new Evaluation<TypeToEvaluate>(objectToEvaluate);
		}
	}
}