namespace FluentEvaluator
{
	public class And
	{
		protected bool EvaluationToPerform
		{
			get;
			set;
		}

		public And(bool evaluationToPerform)
		{
			EvaluationToPerform = evaluationToPerform;	
		}

		public virtual AndWhen When
		{
			get
			{
				return new AndWhen(EvaluationToPerform);
			}
		}
	}
}