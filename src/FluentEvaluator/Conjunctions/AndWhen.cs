using FluentEvaluator.Actions;
using FluentEvaluator.Evaluations;

namespace FluentEvaluator.Conjunctions
{
	public class AndWhen : IAndWhen
	{
		public AndWhen(bool evaluationToPerform)
		{
			EvaluationToPerform = evaluationToPerform;
		}

		protected bool EvaluationToPerform
		{
			get; set;
		}

		public virtual IEvaluationAction This(bool boolToEvaluate)
		{
			EvaluationToPerform &= boolToEvaluate;

			return new EvaluationAction(boolToEvaluate, EvaluationToPerform);
		}

		public virtual AndEvaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new AndEvaluation<TypeToEvaluate>(objectToEvaluate, EvaluationToPerform);
		}
	}
}