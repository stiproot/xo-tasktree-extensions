namespace Xo.TaskTree.Extensions.Tests;

public static class ServiceCollectionFactory
{
    public static IServiceCollection Create() => new ServiceCollection();
}

public static class ServiceProviderFactory
{
    public static IServiceProvider Create() 
        => ServiceCollectionFactory.Create()
            .AddTaskFlowExtensions()
            .BuildServiceProvider();
}