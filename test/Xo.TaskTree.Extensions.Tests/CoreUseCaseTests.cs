namespace Xo.TaskTree.Extensions.Tests;

public class CoreUseCaseTests
{
    private readonly IServiceProvider _provider = ServiceProviderFactory.Create();
    private static CancellationToken NewCancellationToken() => new CancellationToken();

    [Fact]
    public async Task BinaryFlow()
    {
        var ct = NewCancellationToken();
        IFlowBuilder builder = _provider.Get<IFlowBuilder>();
        var flow = builder
            .Root<IY_OutConstBool_SyncService>()
            .If<IY_InBool_OutBool_AsyncService>(
                b => b
                    .Then<IY_InBoolStr_OutConstInt_AsyncService>(
                        c => c
                            .RequireResult()
                            .AddArg("simon", "args")),
                b => b.Else<IService>(),
                c => c.RequireResult()
            );

        var node = flow.Build();
        var msg = await node.Run(ct);
        int data = (msg as Msg<int>)!.GetData();

        data
            .Should()
            .Be(1);
    }

    [Fact]
    public async Task RootWithNodeArg()
    {
        var ct = NewCancellationToken();
        IFlowBuilder builder = _provider.Get<IFlowBuilder>();
        var flow = builder
            .Root<IY_InBool_OutBool_AsyncService>(arg => arg.Arg<IY_OutConstBool_SyncService>());

        var node = flow.Build();
        var msg = await node.Run(ct);
        bool data = (msg as Msg<bool>)!.GetData();

        data
            .Should()
            .Be(true);
    }

    [Fact]
    public async Task NodeAsRootArg()
    {
        var ct = NewCancellationToken();
        IFlowBuilder builder = _provider.Get<IFlowBuilder>();
        var flow = builder
            .Root<IY_OutConstBool_SyncService>()
            .AsArg<IY_InBool_OutBool_AsyncService>();

        var node = flow.Build();
        var msg = await node.Run(ct);
        bool data = (msg as Msg<bool>)!.GetData();

        data
            .Should()
            .Be(true);
    }

    [Fact]
    public async Task ArgWhichItselfIsAFlow()
    {
        var ct = NewCancellationToken();
        IFlowBuilder builder = _provider.Get<IFlowBuilder>();
        var flow = builder
            .Root<IY_InBoolStr_OutConstInt_AsyncService>()
                .Arg(a => a.Root<IY_InStr_OutBool_AsyncService>())
                    .Arg(a => a.Node<IY_InObjBool_OutStr_AsyncService>(c => c.AddArg(true, "flag")));
        
        var node = flow.Build();
        var msg = await node.Run(ct);
        int data = (msg as Msg<int>)!.GetData();

        data
            .Should()
            .Be(1);
    }

    [Fact]
    public async Task RootAsArgs_THEN_TranslatesToPool()
    {
        var ct = NewCancellationToken();
        IFlowBuilder builder = _provider.Get<IFlowBuilder>();
        var flow = builder
            .Root<IY_OutConstBool_SyncService>()
            .AsArgs<IY_InBool_OutBool_AsyncService, IY_InObjBool_OutStr_AsyncService, IY_InStrBool_OutStr_AsyncService>();

        var node = flow.Build();
        var msg = await node.Run(ct);
        bool data = (msg as Msg<bool>)!.GetData();

        data
            .Should()
            .Be(true);
    }

    [Fact]
    public async Task Args()
    {
        var ct = NewCancellationToken();
        IFlowBuilder builder = _provider.Get<IFlowBuilder>();
        var flow = builder
            .Root<IY_InBoolStr_OutConstInt_AsyncService>()
                .Arg<IY_OutConstBool_SyncService>(c => c.NextParam("flag"))
                .Arg<IY_InObjBool_OutStr_AsyncService>(c => c
                    .AddArg(true, "flag")
                    .AddArg(new object(), "obj")
                    .NextParam("args"));
        
        var node = flow.Build();
        var msg = await node.Run(ct);
        int data = (msg as Msg<int>)!.GetData();

        data
            .Should()
            .Be(1);
    }
}