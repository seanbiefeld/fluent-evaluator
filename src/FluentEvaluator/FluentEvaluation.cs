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

		private bool EvaluationToPerform
		{
			get;
			set;
		}

		#endregion

		#region public members

		public EvaluationAction<TypeToPerformEvaluationOn> IsNull()
		{
			EvaluationToPerform = (ObjectToEvaluate == null);
			return new EvaluationAction<TypeToPerformEvaluationOn>(ObjectToEvaluate, EvaluationToPerform);
		}

		#endregion
	}
}