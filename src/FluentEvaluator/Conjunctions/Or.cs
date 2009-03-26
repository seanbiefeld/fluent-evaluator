namespace FluentEvaluator.Conjunctions
{
	public class Or
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

		public Or(bool evaluationToPerform, bool continueEvaluations)
		{
			EvaluationToPerform = evaluationToPerform;
			ContinueEvaluations = continueEvaluations;
		}

		public virtual OrWhen When
		{
			get
			{
				return new OrWhen(EvaluationToPerform, ContinueEvaluations);
			}
		}
	}
}