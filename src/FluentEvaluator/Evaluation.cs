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

		public SingularAction<TypeToEvaluate> IsNull
		{
			get
			{
				EvaluationToPerform = (Equals(ObjectToEvaluate, default(TypeToEvaluate)));
				return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public SingularAction<TypeToEvaluate> IsEmpty
		{
			get
			{
				EvaluationToPerform = EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(ObjectToEvaluate);
				return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public SingularAction<TypeToEvaluate> EqualsThis(object objectToEqual)
		{
			EvaluationToPerform = (ObjectToEvaluate.Equals(objectToEqual));
			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}
        
		public SingularAction<TypeToEvaluate> IsNotNull
		{
			get
			{
				EvaluationToPerform = (!Equals(ObjectToEvaluate, default(TypeToEvaluate)));
				return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public SingularAction<TypeToEvaluate> Satisfies(Predicate<TypeToEvaluate> match)
		{
			EvaluationUtilities.EnsurePredicateIsValid(match);

			EvaluationToPerform = (match(ObjectToEvaluate));

			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		#endregion
	}
}