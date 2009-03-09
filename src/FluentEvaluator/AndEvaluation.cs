using System;

namespace FluentEvaluator
{
	public class AndEvaluation<TypeToEvaluate> : IEvaluation<ConjunctiveAction, TypeToEvaluate>
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

		public ConjunctiveAction IsNull()
		{
			EvaluationToPerform &= (Equals(ObjectToEvaluate, default(TypeToEvaluate)));
			return new ConjunctiveAction(ObjectToEvaluate, EvaluationToPerform);
		}

		public ConjunctiveAction IsEmpty()
		{
			EvaluationToPerform &= EvaluationUtilities.CheckIfObjectToEvaluateIsEmpty(ObjectToEvaluate);

			return new ConjunctiveAction(ObjectToEvaluate, EvaluationToPerform);
		}

		public ConjunctiveAction EqualsThis(object objectToEqual)
		{
			EvaluationToPerform &= (ObjectToEvaluate.Equals(objectToEqual));
			return new ConjunctiveAction(ObjectToEvaluate, EvaluationToPerform);
		}

		public ConjunctiveAction IsNotNull()
		{
			EvaluationToPerform &= (!Equals(ObjectToEvaluate, default(TypeToEvaluate)));
			return new ConjunctiveAction(ObjectToEvaluate, EvaluationToPerform);
		}

		public ConjunctiveAction Satisfies(Predicate<TypeToEvaluate> match)
		{
			When.This(match).IsNull().ThrowAnException<ArgumentNullException>(string.Format("match was null"));

			EvaluationToPerform &= (match(ObjectToEvaluate));

			return new ConjunctiveAction(ObjectToEvaluate, EvaluationToPerform);
		}

		#endregion
	}
}
