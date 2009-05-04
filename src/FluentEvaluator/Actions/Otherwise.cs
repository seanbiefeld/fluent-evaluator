using System;
using System.Reflection;
using FluentEvaluator.Conjunctions;

namespace FluentEvaluator.Actions
{
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
				return new OtherwiseWhen(EvaluationToPerform, CurrentEvaluationConclusion, ContinueEvaluations);
			}
		}

		public EvaluationConclusion ThrowAnException<ExceptionType>(params object[] exceptionArguments) where ExceptionType : Exception
		{
			Action otherwiseActionToPerform = () =>
          	{
				ConstructorInfo currentCtorInfo = typeof(ExceptionType).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, EvaluationUtilities.GetConstructorTypes(exceptionArguments), null);

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