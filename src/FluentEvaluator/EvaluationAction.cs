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
}