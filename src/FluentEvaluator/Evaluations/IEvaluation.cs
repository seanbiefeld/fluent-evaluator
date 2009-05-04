using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public interface IEvaluation<TypeOfAction, TypeToEvaluate> where TypeOfAction : EvaluationAction
	{
		TypeOfAction EqualsThis(TypeToEvaluate objectToEqual);
	}
}