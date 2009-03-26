using System;
using System.Reflection;
using FluentEvaluator.Conjunctions;

namespace FluentEvaluator.Actions
{
	public class EvaluationAction : IEvaluationAction
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

		public And And
		{
			get
			{
				return new And(EvaluationToPerform);
			}
		}

		public Or Or
		{
			get
			{
				return new Or(EvaluationToPerform);
			}
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
	}
}