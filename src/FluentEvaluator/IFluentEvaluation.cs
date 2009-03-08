namespace FluentEvaluator
{
	public interface IFluentEvaluation<TypeToPerformEvaluationOn>
	{
		Action<TypeToPerformEvaluationOn> IsNull();
	}
}