namespace FluentEvaluator
{
	public class OtherwiseWhen : IWhen
	{
		#region Implementation of IWhen

		public Evaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new Evaluation<TypeToEvaluate>(objectToEvaluate);
		}

		public EvaluationAction This(bool boolToEvaluate)
		{
			return new EvaluationAction(boolToEvaluate, boolToEvaluate);
		}

		#endregion
	}
}