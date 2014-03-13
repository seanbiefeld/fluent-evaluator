using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public class NumericEvaluation<TypeToEvaluate> : Evaluation<EvaluationAction, TypeToEvaluate>, INumericEvaluation<EvaluationAction, TypeToEvaluate>
		where TypeToEvaluate : IComparable<TypeToEvaluate>
	{
		public NumericEvaluation(TypeToEvaluate objectToEvaluate, bool continueEvaluations) : base(objectToEvaluate, continueEvaluations)
		{
		}

		public override EvaluationAction EqualsThis(TypeToEvaluate objectToEqual)
		{
			EvaluationToPerform = Equals(CompareType.EqualTo, EvaluationUtilities.GetComparisonType(objectToEqual.CompareTo(ObjectToEvaluate)));
			
			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		public EvaluationAction IsGreaterThan(TypeToEvaluate numericValue)
		{
            EvaluationToPerform = Equals(CompareType.GreaterThan, EvaluationUtilities.GetComparisonType(ObjectToEvaluate.CompareTo(numericValue)));

			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		public EvaluationAction IsLessThan(TypeToEvaluate numericValue)
		{
            EvaluationToPerform = Equals(CompareType.LessThan, EvaluationUtilities.GetComparisonType(numericValue.CompareTo(ObjectToEvaluate)));

			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}
	}
}