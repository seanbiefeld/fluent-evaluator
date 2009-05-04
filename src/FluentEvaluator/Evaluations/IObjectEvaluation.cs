using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public interface IObjectEvaluation<TypeOfAction, TypeToEvaluate> : IEvaluation<TypeOfAction, TypeToEvaluate>
		where TypeOfAction : EvaluationAction
	{
		TypeOfAction IsNull
		{
			get;
		}

		TypeOfAction IsEmpty
		{
			get;
		}

		TypeOfAction IsNotEmpty
		{
			get;
		}

		TypeOfAction IsNotNull
		{
			get;
		}

		TypeOfAction Satisfies(Predicate<TypeToEvaluate> match);
	}
}