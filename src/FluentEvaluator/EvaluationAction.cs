using System;
using System.Reflection;

namespace FluentEvaluator
{
	public class EvaluationAction
	{
		public EvaluationAction(object objectToEvaluate, bool evaluationToPerform)
		{
			ObjectToEvaluate = objectToEvaluate;
			EvaluationToPerform = evaluationToPerform;
		}

        #region properties

		protected object ObjectToEvaluate
		{
			get;
			set;
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

		#endregion

		public EvaluationConclusion ThrowAnException<ExceptionType>(params object[] exceptionArguments) where ExceptionType : Exception
		{
			ActionToPerformAfterEvaluation = () =>
			{
				ConstructorInfo currentCtorInfo = typeof(ExceptionType).GetConstructor(EvaluationUtilities.GetConstructorTypes(exceptionArguments));

				if (currentCtorInfo != null)
					throw (ExceptionType)currentCtorInfo.Invoke(exceptionArguments);
			};
			return new EvaluationConclusion(EvaluationToPerform, ActionToPerformAfterEvaluation);
		}

		public EvaluationConclusion DoThis(Action actionToPerform)
		{
			ActionToPerformAfterEvaluation = actionToPerform;
			return new EvaluationConclusion(EvaluationToPerform, ActionToPerformAfterEvaluation);
		}

		public AndEvaluation<TypeToEvaluate> AndWhenThis<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new AndEvaluation<TypeToEvaluate>(objectToEvaluate, EvaluationToPerform);
		}

		public OrEvaluation<TypeToEvaluate> OrWhenThis<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new OrEvaluation<TypeToEvaluate>(objectToEvaluate, EvaluationToPerform);
		}
	}

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

		public virtual void Engage()
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

	public class OtherwiseAction
	{
		public OtherwiseAction(bool evaluationToPerform, Action actionToPerformAfterEvaluation)
		{
			EvaluationToPerform = evaluationToPerform;
			ActionToPerformAfterEvaluation = actionToPerformAfterEvaluation;
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
		
		public EvaluationConclusion ThrowAnException<ExceptionType>(params object[] exceptionArguments) where ExceptionType : Exception
		{
			Action otherwiseActionToPerform = () =>
			{
				ConstructorInfo currentCtorInfo = typeof(ExceptionType).GetConstructor(EvaluationUtilities.GetConstructorTypes(exceptionArguments));

				if (currentCtorInfo != null)
					throw (ExceptionType)currentCtorInfo.Invoke(exceptionArguments);
			};
			return new EvaluationConclusion(true, ActionToPerformAfterEvaluation, otherwiseActionToPerform);
		}

		public EvaluationConclusion DoThis(Action actionToPerform)
		{
			Action otherwiseActionToPerform = actionToPerform;
			return new EvaluationConclusion(true, ActionToPerformAfterEvaluation, otherwiseActionToPerform);
		}
	}
}