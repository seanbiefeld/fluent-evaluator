using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public class AndEvaluation<TypeToEvaluate> : IEvaluation<EvaluationAction, TypeToEvaluate>
	{
		public AndEvaluation(TypeToEvaluate objectToEvaluate, bool conjuctiveEvaluation)
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
				if(EvaluationToPerform)
					EvaluationToPerform &= (Equals(ObjectToEvaluate, default(TypeToEvaluate)));

				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public EvaluationAction IsEmpty
		{
			get
			{
				if (EvaluationToPerform)
					EvaluationToPerform &= EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(ObjectToEvaluate);

				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public EvaluationAction EqualsThis(object objectToEqual)
		{
			if (EvaluationToPerform)
				EvaluationToPerform &= (ObjectToEvaluate.Equals(objectToEqual));

			return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform);
		}

		public EvaluationAction IsNotNull
		{
			get
			{
				if (EvaluationToPerform)
					EvaluationToPerform &= (!Equals(ObjectToEvaluate, default(TypeToEvaluate)));

				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform);
			}
		}

		public EvaluationAction Satisfies(Predicate<TypeToEvaluate> match)
		{
			if (EvaluationToPerform)
			{
				EvaluationUtilities.EnsurePredicateIsValid(match);

				EvaluationToPerform &= (match(ObjectToEvaluate));
			}

			return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform);
		}

		#endregion
	}
}