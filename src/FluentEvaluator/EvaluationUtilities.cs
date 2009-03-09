using System.Collections;

namespace FluentEvaluator
{
	public class EvaluationUtilities
	{
		public static bool CheckIfObjectToEvaluateIsEmpty(object objectToEvaluate)
		{
			if (objectToEvaluate != null)
			{
				ICollection objectCollection = objectToEvaluate as ICollection;
				if (objectCollection != null)
					return (objectCollection.Count == 0);

				string objectString = objectToEvaluate as string;
				if (objectString != null)
					return (objectString.Length == 0);

			}
			return false;
		}
	}
}
