using System;
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

		public static Type[] GetConstructorTypes(object[] arguments)
		{
			Type[] constructorTypes = new Type[arguments.Length];

			for (int i = 0; i < arguments.Length; i++)
			{
				constructorTypes[i] = arguments[i].GetType();
			}
			return constructorTypes;
		}
	}
}
