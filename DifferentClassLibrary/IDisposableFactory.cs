namespace DifferentClassLibrary;

public interface IDisposableFactory
{
	IDisposable Create();

	Task<IDisposable> CreateAsync();
}
