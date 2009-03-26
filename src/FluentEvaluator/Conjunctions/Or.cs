namespace FluentEvaluator.Conjunctions
{
	public class Or
	{
		protected bool EvaluationToPerform
		{
			get;
			set;
		}

		public Or(bool evaluationToPerform)
		{
			EvaluationToPerform = evaluationToPerform;	
		}

		public virtual OrWhen When
		{
			get
			{
				return new OrWhen(EvaluationToPerform);
			}
		}
	}
}