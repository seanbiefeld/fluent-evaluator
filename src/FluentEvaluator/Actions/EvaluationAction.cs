using System;
using System.Reflection;
using FluentEvaluator.Conjunctions;

namespace FluentEvaluator.Actions
{
	public class EvaluationAction : IEvaluationAction
	{
		//public EvaluationAction(object objectToEvaluate, bool evaluationToPerform)
		//{
		//    ObjectToEvaluate = objectToEvaluate;
		//    EvaluationToPerform = evaluationToPerform;
		//}

		public EvaluationAction(object objectToEvaluate, bool evaluationToPerform, bool continueEvaluations)
		{
			ObjectToEvaluate = objectToEvaluate;
			EvaluationToPerform = evaluationToPerform;
			ContinueEvaluations = continueEvaluations;
		}

		private bool _continueEvaluations = true;
		protected bool ContinueEvaluations
		{ 
			get
			{
				return _continueEvaluations;
			}
			set
			{
				_continueEvaluations = value;
			}
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
				return new And(EvaluationToPerform, ContinueEvaluations);
			}
		}

		public Or Or
		{
			get
			{
				return new Or(EvaluationToPerform, ContinueEvaluations);
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
			return new EvaluationConclusion(EvaluationToPerform, ActionToPerformAfterEvaluation, ContinueEvaluations);
		}

		public EvaluationConclusion DoThis(Action actionToPerform)
		{
			ActionToPerformAfterEvaluation = actionToPerform;
			return new EvaluationConclusion(EvaluationToPerform, ActionToPerformAfterEvaluation, ContinueEvaluations);
		}
	}
}