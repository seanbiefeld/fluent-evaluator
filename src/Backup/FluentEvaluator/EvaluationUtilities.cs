using System;
using System.Collections;

namespace FluentEvaluator
{
	public sealed class EvaluationUtilities
	{
		public static bool CheckIfObjectToEvaluateIsEmpty(object objectToEvaluate)
		{
			return PerfromEmptyCheck(objectToEvaluate, EmptyCheckType.IsEmpty);
		}

		private static bool PerfromEmptyCheck(object objectToEvaluate, EmptyCheckType emptyCheckType)
		{
			if (objectToEvaluate != null)
			{
				switch (emptyCheckType)
				{
					case EmptyCheckType.IsEmpty:
						{
							ICollection objectCollection = objectToEvaluate as ICollection;
							if (objectCollection != null)
								return (objectCollection.Count == 0);
							

							string objectString = objectToEvaluate as string;
							if (objectString != null)
								return (objectString.Length == 0);

							break;
						}
					case EmptyCheckType.IsNotEmpty:
						{
							ICollection objectCollection = objectToEvaluate as ICollection;
							if (objectCollection != null)
								return (objectCollection.Count >= 1);

							string objectString = objectToEvaluate as string;
							if (objectString != null)
								return (objectString.Length >= 1);

							break;
						}
				}
			}
			return false;
		}

		public static bool CheckIfObjectToEvaluateIsNotEmpty(object objectToEvaluate)
		{
			return PerfromEmptyCheck(objectToEvaluate, EmptyCheckType.IsNotEmpty);
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

		public static void EnsurePredicateIsValid<T>(Predicate<T> match)
		{
			When.This(match).IsNull
				.ThrowAnException<Exception>
				(string.Format("Please provide a satisfaction to match against."))
				.Evaluate();
		}

		public static CompareType GetComparisonType(int comparisonValue)
		{
			switch (comparisonValue)
			{
				case -1:
					{
						return CompareType.LessThan;
					}
				case 0:
					{
						return CompareType.EqualTo;
					}
				case 1:
					{
						return CompareType.GreaterThan;
					}
				default:
					{
						return CompareType.InvalidComparison;
					}
			}
		}
	}

	public enum EmptyCheckType
	{
		IsEmpty,
		IsNotEmpty
	}

	public enum CompareType
	{
		LessThan,
		EqualTo,
		GreaterThan,
		InvalidComparison
	}
}
