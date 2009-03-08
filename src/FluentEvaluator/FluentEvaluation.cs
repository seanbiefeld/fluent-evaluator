using System;
using System.Reflection;

namespace FluentEvaluator
{
	public class FluentEvaluation<TypeToPerformEvaluationOn> : IFluentEvaluation<TypeToPerformEvaluationOn>
	{
		public FluentEvaluation(object objectToEvaluate)
		{
			ObjectToEvaluate = objectToEvaluate;
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

		#region public members

		public FluentEvaluation<TypeToPerformEvaluationOn> IsNull()
		{
			EvaluationToPerform = (ObjectToEvaluate == null);
			return this;
		}

		public TypeToPerformEvaluationOn Create(params object[] arguments)
		{
			ActionToPerformAfterEvaluation = () =>
         	{
         		try
         		{
         			ConstructorInfo currentCtorInfo = typeof(TypeToPerformEvaluationOn).GetConstructor(GetConstructorTypes(arguments));
         			ObjectToEvaluate = currentCtorInfo == null ? default(TypeToPerformEvaluationOn) : currentCtorInfo.Invoke(arguments);
         		}
         		catch (Exception ex)
         		{
         			throw new ApplicationException("could not invoke costructor", ex);
         		}
         	};
			PerformAction();
			return (TypeToPerformEvaluationOn)ObjectToEvaluate;
		}

		public void ThrowException<ExceptionType>(params object[] exceptionArguments) where ExceptionType : Exception
		{
			ActionToPerformAfterEvaluation = () =>
 			{
 				ConstructorInfo currentCtorInfo = typeof(ExceptionType).GetConstructor(GetConstructorTypes(exceptionArguments));
 					
				if (currentCtorInfo != null)
 					throw (ExceptionType)currentCtorInfo.Invoke(exceptionArguments);
 			};
			PerformAction();
		}

		#endregion

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