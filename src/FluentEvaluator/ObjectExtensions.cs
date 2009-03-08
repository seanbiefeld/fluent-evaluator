namespace FluentEvaluator
{
	public static class ObjectExtensions
	{
		public static FluentEvaluation<T> When<T>(this object ObjectToEvaluate)
		{
			return new FluentEvaluation<T>(ObjectToEvaluate);
		}
	}
}
