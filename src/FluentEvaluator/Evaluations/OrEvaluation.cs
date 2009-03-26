using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public class OrEvaluation<TypeToEvaluate> : IEvaluation<ConjunctiveAction, TypeToEvaluate>
	{
		public OrEvaluation(TypeToEvaluate objectToEvaluate, bool conjuctiveEvaluation)
		{
			ObjectToEvaluate = objectToEvaluate;
			EvaluationToPerform = conjuctiveEvaluation;
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

		public ConjunctiveAction IsNull
		{
			get
			{
				EvaluationToPerform |= (Equals(ObjectToEvaluate, default(TypeToEvaluate)));
				return new ConjunctiveAction(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public ConjunctiveAction IsEmpty
		{
			get
			{
				EvaluationToPerform |= EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(ObjectToEvaluate);
				return new ConjunctiveAction(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public ConjunctiveAction EqualsThis(object objectToEqual)
		{
			EvaluationToPerform |= (ObjectToEvaluate.Equals(objectToEqual));
			return new ConjunctiveAction(ObjectToEvaluate, EvaluationToPerform);
		}

		public ConjunctiveAction IsNotNull
		{
			get
			{
				EvaluationToPerform |= (!Equals(ObjectToEvaluate, default(TypeToEvaluate)));
				return new ConjunctiveAction(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public ConjunctiveAction Satisfies(Predicate<TypeToEvaluate> match)
		{
			EvaluationUtilities.EnsurePredicateIsValid(match);

			EvaluationToPerform |= (match(ObjectToEvaluate));

			return new ConjunctiveAction(ObjectToEvaluate, EvaluationToPerform);
		}
        
		#endregion
	}
}