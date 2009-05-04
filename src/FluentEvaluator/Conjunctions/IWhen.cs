using FluentEvaluator.Actions;
using FluentEvaluator.Evaluations;

namespace FluentEvaluator.Conjunctions
{
	public interface IWhen
	{
		NumericEvaluation<int> This(int numberToEvaluate);

		NumericEvaluation<double> This(double numberToEvaluate);

		NumericEvaluation<float> This(float numberToEvaluate);

		NumericEvaluation<long> This(long numberToEvaluate);

		NumericEvaluation<short> This(short numberToEvaluate);

		NumericEvaluation<decimal> This(decimal numberToEvaluate);

		NumericEvaluation<uint> This(uint numberToEvaluate);

		NumericEvaluation<ulong> This(ulong numberToEvaluate);

		NumericEvaluation<ushort> This(ushort numberToEvaluate);
	}

	public interface ISingularWhen : IWhen
	{
		IEvaluation<SingularAction<TypeToEvaluate>, TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate);
	}
}