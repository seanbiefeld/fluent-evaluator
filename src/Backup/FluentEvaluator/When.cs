using FluentEvaluator.Actions;
using FluentEvaluator.Evaluations;

namespace FluentEvaluator
{
	public class When
	{
		public static ObjectEvaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new ObjectEvaluation<TypeToEvaluate>(objectToEvaluate, true);
		}

		public static EvaluationAction This(bool boolToEvaluate)
		{
			return new EvaluationAction(boolToEvaluate, boolToEvaluate, true);
		}

		public static NumericEvaluation<int> This(int numberToEvaluate)
		{
			return new NumericEvaluation<int>(numberToEvaluate, true);
		}

		public static NumericEvaluation<double> This(double numberToEvaluate)
		{
			return new NumericEvaluation<double>(numberToEvaluate, true);
		}

		public static NumericEvaluation<float> This(float numberToEvaluate)
		{
			return new NumericEvaluation<float>(numberToEvaluate, true);
		}

		public static NumericEvaluation<long> This(long numberToEvaluate)
		{
			return new NumericEvaluation<long>(numberToEvaluate, true);
		}

		public static NumericEvaluation<short> This(short numberToEvaluate)
		{
			return new NumericEvaluation<short>(numberToEvaluate, true);
		}

		public static NumericEvaluation<decimal> This(decimal numberToEvaluate)
		{
			return new NumericEvaluation<decimal>(numberToEvaluate, true);
		}

		public static NumericEvaluation<uint> This(uint numberToEvaluate)
		{
			return new NumericEvaluation<uint>(numberToEvaluate, true);
		}

		public static NumericEvaluation<ulong> This(ulong numberToEvaluate)
		{
			return new NumericEvaluation<ulong>(numberToEvaluate, true);
		}

		public static NumericEvaluation<ushort> This(ushort numberToEvaluate)
		{
			return new NumericEvaluation<ushort>(numberToEvaluate, true);
		}
	}
}