using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xo.TaskTree.DependencyInjection.Extensions;

namespace Xo.TaskTree.Extensions.DependencyInjection;

public static class TaskFlowServiceCollectionExtensions
{
    public static IServiceCollection AddTaskFlowExtensions(this IServiceCollection @this)
    {
        return @this
            .AddTaskFlowServices()
            .AddFrameworkServices();
    }

    private static IServiceCollection AddFrameworkServices(this IServiceCollection @this)
        => @this.XTryAddSingleton<IFlowBuilder, FlowBuilder>();

    private static IServiceCollection XTryAddSingleton<I, T>(this IServiceCollection @this)
        where I: class
        where T: class, I
    {
        @this.TryAddSingleton<I, T>();
        return @this;
    }
}