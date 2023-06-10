namespace Xo.TaskTree.Extensions;

internal static class LambdaExtensions
{
    public static INodeConfiguration BuildConfiguration(this Action<INodeConfigurationBuilder> @this)
    {
        var builder = new NodeConfigurationBuilder();
        @this(builder);
        return builder.Build();
    }

    public static INode BuildNode(this Action<IFlowBuilder> @this)
    {
        var builder = new FlowBuilder();
        @this(builder);
        return builder.Build();
    }
}