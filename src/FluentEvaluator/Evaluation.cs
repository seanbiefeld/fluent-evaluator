using System;

namespace FluentEvaluator
{
	public class Evaluation<TypeToEvaluate> : IEvaluation<SingularAction<TypeToEvaluate>, TypeToEvaluate>
	{
		public Evaluation(TypeToEvaluate objectToEvaluate)
		{
			ObjectToEvaluate = objectToEvaluate;
		}

		#region properties

		protected virtual TypeToEvaluate ObjectToEvaluate
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
			EvaluationToPerform = (Equals(ObjectToEvaluate, default(TypeToEvaluate)));
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
			EvaluationToPerform = (!Equals(ObjectToEvaluate, default(TypeToEvaluate)));
			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		public SingularAction<TypeToEvaluate> Satisfies(Predicate<TypeToEvaluate> match)
		{
			When.This(match).IsNull().ThrowAnException<ArgumentNullException>(string.Format("match was null"));

			EvaluationToPerform = (match(ObjectToEvaluate));

			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		#endregion
	}
}