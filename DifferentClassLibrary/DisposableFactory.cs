namespace DifferentClassLibrary;

public class DisposableFactory : IDisposableFactory
{
	public IDisposable Create() => new HttpRequestMessage();

	public Task<IDisposable> CreateAsync() => Task.FromResult((IDisposable)new HttpRequestMessage());
}
