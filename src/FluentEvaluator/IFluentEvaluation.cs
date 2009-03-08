namespace FluentEvaluator
{
	public interface IFluentEvaluation<TypeToPerformEvaluationOn>
	{
		EvaluationAction<TypeToPerformEvaluationOn> IsNull();
	}
}