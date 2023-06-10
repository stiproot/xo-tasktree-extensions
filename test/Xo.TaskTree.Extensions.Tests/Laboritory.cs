namespace Xo.TaskTree.Extensions.Tests;

public class Laboritory
{
    private readonly IServiceProvider _provider = ServiceProviderFactory.Create();
    private static CancellationToken NewCancellationToken() => new CancellationToken();

    [Fact]
    public async Task Beta()
    {
        // var ct = NewCancellationToken(); 
        IXFlowBuilder builder = _provider.Get<IXFlowBuilder>();

        builder
            .Root<IY_InBool_OutBool_AsyncService>()
            .Arg<IY_OutConstBool_SyncService>()
            .Next<IY_InBool_OutBool_AsyncService>();
    }
}