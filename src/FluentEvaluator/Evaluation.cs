namespace FluentEvaluator
{
	public class Evaluation<TypeToEvaluate> : IEvaluation<SingularAction<TypeToEvaluate>>
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

		public SingularAction<TypeToEvaluate> IsNull()
		{
			EvaluationToPerform = (ObjectToEvaluate == null);
			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		public SingularAction<TypeToEvaluate> IsEmpty()
		{
			EvaluationToPerform = EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(ObjectToEvaluate);

			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		public SingularAction<TypeToEvaluate> EqualsThis(object objectToEqual)
		{
			EvaluationToPerform = (ObjectToEvaluate.Equals(objectToEqual));
			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}
        
		public SingularAction<TypeToEvaluate> IsNotNull()
		{
			EvaluationToPerform = (ObjectToEvaluate != null);
			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		#endregion
	}
}