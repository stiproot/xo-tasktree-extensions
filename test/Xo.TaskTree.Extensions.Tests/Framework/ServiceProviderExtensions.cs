namespace Xo.TaskTree.Extensions.Tests;

internal static class ServiceProviderExtensions
{
    public static T Get<T>(this IServiceProvider @this) => (T)@this.GetService<T>()!;
}