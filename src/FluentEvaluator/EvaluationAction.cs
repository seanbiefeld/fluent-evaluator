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

		public void ThrowAnException<ExceptionType>(params object[] exceptionArguments) where ExceptionType : Exception
		{
			ActionToPerformAfterEvaluation = () =>
			{
				ConstructorInfo currentCtorInfo = typeof(ExceptionType).GetConstructor(GetConstructorTypes(exceptionArguments));

				if (currentCtorInfo != null)
					throw (ExceptionType)currentCtorInfo.Invoke(exceptionArguments);
			};
			PerformAction();
		}

		public void DoThis(Action actionToPerform)
		{
			ActionToPerformAfterEvaluation = actionToPerform;
			PerformAction();
		}

		public AndEvaluation<TypeToEvaluate> AndWhenThis<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new AndEvaluation<TypeToEvaluate>(objectToEvaluate, EvaluationToPerform);
		}

		public OrEvaluation<TypeToEvaluate> OrWhenThis<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new OrEvaluation<TypeToEvaluate>(objectToEvaluate, EvaluationToPerform);
		}

		#region private members

		protected void PerformAction()
		{
			if (EvaluationToPerform)
				ActionToPerformAfterEvaluation();
		}

		protected static Type[] GetConstructorTypes(object[] arguments)
		{
			Type[] constructorTypes = new Type[arguments.Length];

			for (int i = 0; i < arguments.Length; i++)
			{
				constructorTypes[i] = arguments[i].GetType();
			}
			return constructorTypes;
		}

		#endregion
	}
}