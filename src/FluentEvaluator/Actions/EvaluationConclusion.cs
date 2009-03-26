using System;
using System.Reflection;
using FluentEvaluator.Conjunctions;

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

	public class Otherwise
	{
		public Otherwise(bool evaluationToPerform, Action actionToPerformAfterEvaluation, EvaluationConclusion evaluationConclusion, bool continueEvaluations)
		{
			EvaluationToPerform = evaluationToPerform;
			ActionToPerformAfterEvaluation = actionToPerformAfterEvaluation;
			CurrentEvaluationConclusion = evaluationConclusion;
			ContinueEvaluations = continueEvaluations;
		}

		protected Action ActionToPerformAfterEvaluation
		{
			get;
			set;
		}

		protected bool EvaluationToPerform
		{
			get;
			set;
		}

		protected EvaluationConclusion CurrentEvaluationConclusion
		{
			get;
			set;
		}

		protected bool ContinueEvaluations
		{
			get;
			set;
		}

		public virtual OtherwiseWhen When
		{
			get
			{
				return new OtherwiseWhen(EvaluationToPerform, CurrentEvaluationConclusion);
			}
		}

		public EvaluationConclusion ThrowAnException<ExceptionType>(params object[] exceptionArguments) where ExceptionType : Exception
		{
			Action otherwiseActionToPerform = () =>
			{
				ConstructorInfo currentCtorInfo = typeof(ExceptionType).GetConstructor(EvaluationUtilities.GetConstructorTypes(exceptionArguments));

				if (currentCtorInfo != null)
					throw (ExceptionType)currentCtorInfo.Invoke(exceptionArguments);
			};
			return new EvaluationConclusion(EvaluationToPerform, ActionToPerformAfterEvaluation, otherwiseActionToPerform, ContinueEvaluations);
		}

		public EvaluationConclusion DoThis(Action actionToPerform)
		{
			Action otherwiseActionToPerform = actionToPerform;
			return new EvaluationConclusion(EvaluationToPerform, ActionToPerformAfterEvaluation, otherwiseActionToPerform, ContinueEvaluations);
		}
	}
}