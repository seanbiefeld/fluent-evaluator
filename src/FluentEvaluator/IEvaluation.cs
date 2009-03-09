using System;

namespace FluentEvaluator
{
	public interface IEvaluation<TypeOfAction, TypeToEvaluate> where TypeOfAction : EvaluationAction
	{
		TypeOfAction IsNull();

		TypeOfAction IsEmpty();

		TypeOfAction EqualsThis(object objectToEqual);

		TypeOfAction IsNotNull();

		TypeOfAction Satisfies(Predicate<TypeToEvaluate> match);
	}
}