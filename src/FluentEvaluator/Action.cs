using System;
using System.Reflection;

namespace FluentEvaluator
{
	public class Action<TypeToEvaluate>
	{
		public Action(object objectToEvaluate, bool evaluationToPerform)
		{
			ObjectToEvaluate = objectToEvaluate;
			EvaluationToPerform = evaluationToPerform;
		}

        #region properties

		private object ObjectToEvaluate
		{
			get;
			set;
		}

		private Action ActionToPerformAfterEvaluation
		{
			get;
			set;
		}

		private bool EvaluationToPerform
		{
			get;
			set;
		}

		#endregion

		public TypeToEvaluate CreateIt(params object[] arguments)
		{
			ActionToPerformAfterEvaluation = () =>
			{
				try
				{
					ConstructorInfo currentCtorInfo = typeof(TypeToEvaluate).GetConstructor(GetConstructorTypes(arguments));
					ObjectToEvaluate = currentCtorInfo == null ? default(TypeToEvaluate) : currentCtorInfo.Invoke(arguments);
				}
				catch (Exception ex)
				{
					throw new ApplicationException("could not invoke costructor", ex);
				}
			};
			PerformAction();
			return (TypeToEvaluate)ObjectToEvaluate;
		}

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

		#region private members

		private void PerformAction()
		{
			if (EvaluationToPerform)
				ActionToPerformAfterEvaluation();
		}

		private static Type[] GetConstructorTypes(object[] arguments)
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