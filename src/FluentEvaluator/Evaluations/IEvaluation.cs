using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public interface IEvaluation<TypeOfAction, TypeToEvaluate> where TypeOfAction : EvaluationAction
	{
		TypeOfAction IsNull{ get; }

		TypeOfAction IsEmpty{ get; }

		TypeOfAction EqualsThis(object objectToEqual);

		TypeOfAction IsNotNull{ get; }

		TypeOfAction Satisfies(Predicate<TypeToEvaluate> match);
	}
}