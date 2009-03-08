namespace FluentEvaluator
{
	public class FluentEvaluation<TypeToPerformEvaluationOn> : IFluentEvaluation<TypeToPerformEvaluationOn>
	{
		public FluentEvaluation(object objectToEvaluate)
		{
			ObjectToEvaluate = objectToEvaluate;
		}

		#region properties

		protected virtual object ObjectToEvaluate
		{
			get;
			set;
		}

		protected virtual bool EvaluationToPerform
		{
			get;
			set;
		}

		#endregion

		#region public members

		public EvaluationAction<TypeToPerformEvaluationOn> IsNull()
		{
			EvaluationToPerform = (ObjectToEvaluate == null);
			return new EvaluationAction<TypeToPerformEvaluationOn>(ObjectToEvaluate, EvaluationToPerform);
		}

		#endregion
	}
}