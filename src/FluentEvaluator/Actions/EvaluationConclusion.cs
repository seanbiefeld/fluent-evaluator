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

		public OtherwiseAction Otherwise
		{ 
			get
			{
				return new OtherwiseAction(EvaluationToPerform, ActionToPerformAfterEvaluation);
			}
		}

		public EvaluationConclusion(bool evaluationToPerform, Action actionToPerformAfterEvaluation)
		{
			EvaluationToPerform = evaluationToPerform;
			ActionToPerformAfterEvaluation = actionToPerformAfterEvaluation;
		}

		public EvaluationConclusion(bool evaluationToPerform, Action actionToPerformAfterEvaluation, Action otherwiseActionToPerformAfterEvaluation)
		{
			EvaluationToPerform = evaluationToPerform;
			ActionToPerformAfterEvaluation = actionToPerformAfterEvaluation;
			OtherwiseActionToPerformAfterEvaluation = otherwiseActionToPerformAfterEvaluation;
		}

		public virtual void Evaluate()
		{
			PerformAction();
		}

		protected void PerformAction()
		{
			if (EvaluationToPerform)
				ActionToPerformAfterEvaluation();
			else
			{
				if(OtherwiseActionToPerformAfterEvaluation != null)
					OtherwiseActionToPerformAfterEvaluation();
			}
		}

	}
}