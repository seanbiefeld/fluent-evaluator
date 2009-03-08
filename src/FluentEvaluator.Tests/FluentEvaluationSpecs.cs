namespace FluentEvaluator.Tests
{
	public class FluentEvaluationSpecs
	{
	}

	public class when_checking_if_null
	{
		protected void Context()
		{
			Foo currentFoo = null;

			currentFoo
				.When<Foo>()
				.IsNull()
				.Instantiate();
		}
	}

    public class Foo
	{

	}
}