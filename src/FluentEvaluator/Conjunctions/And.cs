namespace FluentEvaluator.Conjunctions
{
	public class And
	{
		protected bool EvaluationToPerform
		{
			get;
			set;
		}

		protected bool ContinueEvaluations
		{
			get;
			set;
		}

		public And(bool evaluationToPerform, bool continueEvaluations)
		{
			EvaluationToPerform = evaluationToPerform;
			ContinueEvaluations = continueEvaluations;
		}

		public virtual AndWhen When
		{
			get
			{
				return new AndWhen(EvaluationToPerform, ContinueEvaluations);
			}
		}
	}
}