namespace FluentEvaluator
{
	public class Evaluation<TypeToEvaluate> : IFluentEvaluation<TypeToEvaluate>
	{
		public Evaluation(object objectToEvaluate)
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

		public Action<TypeToEvaluate> IsNull()
		{
			EvaluationToPerform = (ObjectToEvaluate == null);
			return new Action<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		#endregion
	}
}