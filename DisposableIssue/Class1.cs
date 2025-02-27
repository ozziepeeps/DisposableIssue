using DifferentClassLibrary;

namespace DisposableIssue;

public class Class1
{
	private readonly IDisposableFactory _factory;

	public Class1(IDisposableFactory factory)
	{
		_factory = factory;
	}

	public async Task Method()
	{
		// Getting IDisposables from a method local to the type,
		// CA2000 triggers correctly, as I am not disposing the returned references:
#pragma warning disable CA1849 // Call async methods when in an async method
		var needsDisposing1 = Create();
#pragma warning restore CA1849 // Call async methods when in an async method

		var needsDisposing2 = await CreateAsync().ConfigureAwait(false);


		// However, when getting IDisposables from a factory in a different assembly,
		// CA2000 is not triggered, despite me not dispoing the returned references:
#pragma warning disable CA1849 // Call async methods when in an async method
		var needsDisposing3 = _factory.Create();
#pragma warning restore CA1849 // Call async methods when in an async method

		var needsDisposing4 = await _factory.CreateAsync().ConfigureAwait(false);
	}

	public static IDisposable Create()
	{
		return new HttpRequestMessage();
	}

	public static Task<IDisposable> CreateAsync()
	{
		return Task.FromResult((IDisposable)new HttpRequestMessage());
	}
}
