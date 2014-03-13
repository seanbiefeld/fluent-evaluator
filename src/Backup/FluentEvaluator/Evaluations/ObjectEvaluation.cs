using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public class ObjectEvaluation<TypeToEvaluate> : Evaluation<SingularAction<TypeToEvaluate>, TypeToEvaluate>, IObjectEvaluation<SingularAction<TypeToEvaluate>, TypeToEvaluate>
	{
		#region public members

		public ObjectEvaluation(TypeToEvaluate objectToEvaluate, bool continueEvaluations) : base(objectToEvaluate, continueEvaluations)
		{
		}

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

		public SingularAction<TypeToEvaluate> IsNotEmpty
		{
			get
			{
				EvaluationToPerform = EvaluationUtilities.CheckIfObjectToEvaluateIsNotEmpty(ObjectToEvaluate);
				return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public override SingularAction<TypeToEvaluate> EqualsThis(TypeToEvaluate objectToEqual)
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