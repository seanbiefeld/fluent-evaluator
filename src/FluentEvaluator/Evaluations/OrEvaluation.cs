using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public class OrEvaluation<TypeToEvaluate> : IEvaluation<EvaluationAction, TypeToEvaluate>
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

		public EvaluationAction IsNull
		{
			get
			{
				EvaluationToPerform |= (Equals(ObjectToEvaluate, default(TypeToEvaluate)));
				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public EvaluationAction IsEmpty
		{
			get
			{
				EvaluationToPerform |= EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(ObjectToEvaluate);
				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public EvaluationAction EqualsThis(object objectToEqual)
		{
			EvaluationToPerform |= (ObjectToEvaluate.Equals(objectToEqual));
			return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform);
		}

		public EvaluationAction IsNotNull
		{
			get
			{
				EvaluationToPerform |= (!Equals(ObjectToEvaluate, default(TypeToEvaluate)));
				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public EvaluationAction Satisfies(Predicate<TypeToEvaluate> match)
		{
			EvaluationUtilities.EnsurePredicateIsValid(match);

			EvaluationToPerform |= (match(ObjectToEvaluate));

			return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform);
		}
        
		#endregion
	}
}