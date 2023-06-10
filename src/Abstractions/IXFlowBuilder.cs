namespace Xo.TaskTree.Extensions.Abstractions;

public interface IXFlowStage : IRoot, IAsArgFlow, INextFlow
{
    INode Focus { get; set; }
}

public interface IRoot
{
    IXFlowStage Root<T>();
}

public interface IAsArgFlow
{
    IXFlowStage AsArg<T>();
}

public interface INextFlow
{
    IXFlowStage Next<T>();
}

public class XFlowStage : IXFlowStage
{
    protected readonly INodeBuilderFactory _NodeBuilderFactory;
    public INode Focus { get; set; }

    public IXFlowStage Root<T>()
    {
        this.Focus = this._NodeBuilderFactory
            .Linked()
            .AddFunctory<T>()
            .Build();

        return this;
    }

    public IXFlowStage AsArg<T>()
    {
        var arg = this._NodeBuilderFactory
            .Create()
            .AddFunctory<T>()
            .Build();

        this.Focus.AddArg(arg);

        return this;
    }

    public IXFlowStage Next<T>()
    {
        var next = this._NodeBuilderFactory
            .Create()
            .AddFunctory<T>()
            .Build();
        
        this.Focus.
        
    }
}

public interface IXFlowBuilder
{
    IXFlowBuilder Root<T>();
    IXFlowBuilder Root<T>(Action<INodeConfigurationBuilder> config);
    IXFlowBuilder Root<T>(Action<IXFlowBuilder> arg);
    IXFlowBuilder Root<T>(
        Action<IXFlowBuilder> arg,
        Action<INodeConfigurationBuilder> config
    );
    INode Root<T>(
        Action<INodeConfigurationBuilder> config,
        Action<IXFlowBuilder> arg,
        Action<IXFlowBuilder> next
    );

    IXFlowBuilder Arg<T>();
    IXFlowBuilder Arg<T>(Action<INodeConfigurationBuilder> config);
    IXFlowBuilder Arg(Action<IXFlowBuilder> arg);

    IXFlowBuilder AsArg<T>();
    IXFlowBuilder AsArgs<T, U, V>();

    IXFlowBuilder If<T>(
        Action<IXFlowBuilder> then,
        Action<IXFlowBuilder> @else
    );
    IXFlowBuilder If<T, TResolver>(
        Action<IXFlowBuilder> then,
        Action<IXFlowBuilder> @else
    );
    IXFlowBuilder If<T>(
        Action<IXFlowBuilder> then,
        Action<IXFlowBuilder> @else,
        Action<INodeConfigurationBuilder> config
    );
    IXFlowBuilder If<T, TResolver>(
        Action<IXFlowBuilder> then,
        Action<IXFlowBuilder> @else,
        Action<INodeConfigurationBuilder> config
    );

    INode If<T>(
        Action<INodeConfigurationBuilder> config,
        Action<IXFlowBuilder> then,
        Action<IXFlowBuilder> @else
    );

    IXFlowBuilder Then<T>();
    IXFlowBuilder Then<T>(Action<INodeConfigurationBuilder> config);
    INode Then<T>(
        Action<INodeConfigurationBuilder> config,
        Action<IXFlowBuilder> then
    );

    IXFlowBuilder Else<T>();
    IXFlowBuilder Else<T>(Action<INodeConfigurationBuilder> config);

    IXFlowBuilder Pool<T, U, V>();
    INode Pool<T, U, V>(
        Action<INodeConfigurationBuilder> tConfig,
        Action<INodeConfigurationBuilder> uConfig,
        Action<INodeConfigurationBuilder> vConfig,
        Action<IXFlowBuilder>? then = null
    );

    IXFlowBuilder Next<T>();
    IXFlowBuilder Hash<T, U, V>();

    IXFlowBuilder Node<T>();
    IXFlowBuilder Node<T>(Action<INodeConfigurationBuilder> config);

    IXFlowBuilder With(Expression<Action<INodeConfigurationBuilder>> config);

    INode Build();
}