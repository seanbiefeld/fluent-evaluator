using System;

namespace FluentEvaluator
{
	public class FluentEvaluation<T> where T : new()
	{
		public FluentEvaluation(object objectToEvaluate)
		{
			ObjectToEvaluate = objectToEvaluate;
		}

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

		public FluentEvaluation<T> IsNull()
		{
			EvaluationToPerform = (ObjectToEvaluate == null);
			return this;
		}

		public void Instantiate()
		{
			ActionToPerformAfterEvaluation = () => ObjectToEvaluate = new T();
			PerformAction();
		}

		//public void InstantiateWithArguments(params object[] arguments)
		//{
		//    ActionToPerformAfterEvaluation = () => ObjectToEvaluate = new T(arguments);
		//    PerformAction();
		//}

		private void PerformAction()
		{
			if (EvaluationToPerform)
				ActionToPerformAfterEvaluation();
		}
	}
}
