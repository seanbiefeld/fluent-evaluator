namespace FluentEvaluator
{
	public interface IEvaluation<TypeOfAction> where TypeOfAction : EvaluationAction
	{
		TypeOfAction IsNull();

		TypeOfAction IsEmpty();

		TypeOfAction EqualsThis(object objectToEqual);
	}
}