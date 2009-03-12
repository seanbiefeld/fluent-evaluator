namespace FluentEvaluator
{
	public class When 
	{
		public static Evaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new Evaluation<TypeToEvaluate>(objectToEvaluate);
		}

		public static EvaluationAction This(bool boolToEvaluate)
		{
			return new EvaluationAction(boolToEvaluate, boolToEvaluate);
		}
	}
}