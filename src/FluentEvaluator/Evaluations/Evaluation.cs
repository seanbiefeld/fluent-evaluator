using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public abstract class Evaluation<TypeOfAction, TypeToEvaluate> : IEvaluation<TypeOfAction, TypeToEvaluate> where TypeOfAction : EvaluationAction
	{
		protected Evaluation(TypeToEvaluate objectToEvaluate, bool continueEvaluations)
		{
			ObjectToEvaluate = objectToEvaluate;
			ContinueEvaluations = continueEvaluations;
		}

		protected bool ContinueEvaluations { get; set; }

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

		public abstract TypeOfAction EqualsThis(TypeToEvaluate objectToEqual);
	}
}