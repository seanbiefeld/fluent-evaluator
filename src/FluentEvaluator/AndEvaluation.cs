namespace FluentEvaluator
{
	public class AndEvaluation
	{
		public AndEvaluation(object objectToEvaluate, bool conjuctiveEvaluation)
		{
			ObjectToEvaluate = objectToEvaluate;
			EvaluationToPerform = conjuctiveEvaluation;
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

		public ConjunctiveAction IsNull()
		{
			EvaluationToPerform &= (ObjectToEvaluate == null);
			return new ConjunctiveAction(ObjectToEvaluate, EvaluationToPerform);
		}

		public ConjunctiveAction EqualsThis(object objectToEqual)
		{
			EvaluationToPerform &= (ObjectToEvaluate.Equals(objectToEqual));
			return new ConjunctiveAction(ObjectToEvaluate, EvaluationToPerform);
		}

		#endregion
	}
}
