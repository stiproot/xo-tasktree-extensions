namespace Xo.TaskTree.Extensions.Tests;

public class ComplexUseCaseTests
{
    private readonly IServiceProvider _provider = ServiceProviderFactory.Create();
    private static CancellationToken NewCancellationToken() => new CancellationToken();

    [Fact]
    public async Task ComplexFlow()
    {
        var ct = NewCancellationToken();
        IFlowBuilder builder = _provider.Get<IFlowBuilder>();

        var node = builder
            .Root<IY_InBoolStr_OutConstInt_AsyncService>(
                config => config.AddArg("simon", "args"),
                arg => arg.Node<IY_OutConstBool_SyncService>(),
                then => then.If<IY_InInt_OutBool_SyncService>(
                    config => config.RequireResult(),
                    then => then
                        .Then<IY_InBoolStr_OutConstInt_AsyncService>(
                            config => config.RequireResult().AddArg("simon", "args"),
                            then => then.Then<IY_InInt_OutBool_SyncService>(
                                config => config.RequireResult(),
                                then => then.Pool<IY_InBool_OutBool_AsyncService, IY_InObjBool_OutStr_AsyncService, IY_InStr_AsyncService>(
                                    tConfig => tConfig.RequireResult(),
                                    uConfig => uConfig.RequireResult(),
                                    vConfig => vConfig.RequireResult()
                                )
                            )
                        ),
                    @else => @else.Else<IService>()
                ));

        var msg = await node.Run(ct);
        int data = (msg as Msg<int>)!.GetData();

        data
            .Should()
            .Be(1);
    }
}