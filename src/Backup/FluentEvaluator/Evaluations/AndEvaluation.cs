using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public class AndEvaluation<TypeToEvaluate> : IObjectEvaluation<EvaluationAction, TypeToEvaluate>
	{
		public AndEvaluation(TypeToEvaluate objectToEvaluate, bool conjuctiveEvaluation, bool continueEvaluations)
		{
			ObjectToEvaluate = objectToEvaluate;
			EvaluationToPerform = conjuctiveEvaluation;
			ContinueEvaluations = continueEvaluations;
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

		protected virtual bool ContinueEvaluations
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

				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public EvaluationAction IsEmpty
		{
			get
			{
				if (EvaluationToPerform)
					EvaluationToPerform &= EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(ObjectToEvaluate);

				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public EvaluationAction IsNotEmpty
		{
			get
			{
				if (EvaluationToPerform)
					EvaluationToPerform &= EvaluationUtilities.CheckIfObjectToEvaluateIsNotEmpty(ObjectToEvaluate);

				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public EvaluationAction EqualsThis(TypeToEvaluate objectToEqual)
		{
			if (EvaluationToPerform)
				EvaluationToPerform &= (ObjectToEvaluate.Equals(objectToEqual));

			return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
		}

		public EvaluationAction IsNotNull
		{
			get
			{
				if (EvaluationToPerform)
					EvaluationToPerform &= (!Equals(ObjectToEvaluate, default(TypeToEvaluate)));

				return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
			}
		}

		public EvaluationAction Satisfies(Predicate<TypeToEvaluate> match)
		{
			if (EvaluationToPerform)
			{
				EvaluationUtilities.EnsurePredicateIsValid(match);

				EvaluationToPerform &= (match(ObjectToEvaluate));
			}

			return new EvaluationAction(ObjectToEvaluate, EvaluationToPerform, ContinueEvaluations);
		}

		#endregion
	}
}