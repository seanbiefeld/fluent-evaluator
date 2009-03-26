namespace FluentEvaluator
{
	public class OrWhen : IOrWhen
	{
		public OrWhen(bool evaluationToPerform)
		{
			EvaluationToPerform = evaluationToPerform;
		}

		protected bool EvaluationToPerform
		{
			get; set;
		}

		public virtual IEvaluationAction This(bool boolToEvaluate)
		{
			EvaluationToPerform |= boolToEvaluate;

			return new EvaluationAction(boolToEvaluate, EvaluationToPerform);
		}

		public virtual OrEvaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new OrEvaluation<TypeToEvaluate>(objectToEvaluate, EvaluationToPerform);
		}
	}
}
