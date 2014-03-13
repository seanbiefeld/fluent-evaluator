using System;

namespace FluentEvaluator.Actions
{
	public class EvaluationConclusion
	{
		protected Action ActionToPerformAfterEvaluation
		{
			get;
			set;
		}

		protected Action OtherwiseActionToPerformAfterEvaluation
		{
			get;
			set;
		}


		protected bool EvaluationToPerform
		{
			get;
			set;
		}

		protected bool ContinueEvaluations
		{
			get;
			set;
		}

		public Otherwise Otherwise
		{
			get
			{
				return new Otherwise(EvaluationToPerform, ActionToPerformAfterEvaluation, this, ContinueEvaluations);
			}
		}

		public EvaluationConclusion(bool evaluationToPerform, Action actionToPerformAfterEvaluation, bool continueEvaluations)
		{
			EvaluationToPerform = evaluationToPerform;
			ActionToPerformAfterEvaluation = actionToPerformAfterEvaluation;
			ContinueEvaluations = continueEvaluations;
		}

		public EvaluationConclusion(bool evaluationToPerform, Action actionToPerformAfterEvaluation, Action otherwiseActionToPerformAfterEvaluation, bool continueEvaluations)
		{
			EvaluationToPerform = evaluationToPerform;
			ActionToPerformAfterEvaluation = actionToPerformAfterEvaluation;
			OtherwiseActionToPerformAfterEvaluation = otherwiseActionToPerformAfterEvaluation;
			ContinueEvaluations = continueEvaluations;
		}

		public virtual void Evaluate()
		{
			PerformAction();
		}

		internal virtual void Evaluate(bool continueEvaluations)
		{
			ContinueEvaluations = continueEvaluations;
			PerformAction();
		}

		protected void PerformAction()
		{
            if(ContinueEvaluations)
			{
				if (EvaluationToPerform)
					ActionToPerformAfterEvaluation();
				else
				{
					if (OtherwiseActionToPerformAfterEvaluation != null)
						OtherwiseActionToPerformAfterEvaluation();
				}
			}
		}

	}
}