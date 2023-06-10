## Node Types
### There needs to types of node abstratctions in a flow
1. A movement
2. A functory

In most cases, the movement is implicit...

Examples:
Then<T> is a movement, but a default node can be inferred
MoveTo -> movement, but a target node needs to be specified

## Node Traversal
### Root
Root<T> // specifies the root node, that will be awaited

Root<T>(c => c.Arg<Y>()) // Y results in an argument for T: T.t(Y.y) [in-review]
Root<T>().AsArg<Y>() // Linked Node is implied with, with Y requiring result [in-review]
Root<T>().AsArgs<X, Y>() // Pool Node is implied with, with X and Y both requiring results (unless opted out) [in-review]

## Conditional Nodes
### If
If<T> -> Then<R> // If defines binary functory, Then defines the true-conditional transition.
If<T> -> If<R> // true-conditional is implicit.

If<T> -> Pool<X, Y, Z> : Else<R> // if, then, else
If<T> -> Pool<X, Y, Z> // if, then
If<T> -> Else<R> // if, else

## Laws 
1. If a node directly references other nodes, then the node type needs to be defined upfront. Which would require building the tree in reverse (I think), which seems unrealistic.
2. It the lowest level, nodes should be as simple as possible.

## Building
### Nested

```c#
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
```

### Fluent

Ideally, workflow construction should be as fluent and intuitive as possible...

```c#
var flow = builder
            .Root<IY_InBoolStr_OutConstInt_AsyncService>(
                arg => arg
                        .Node<IY_OutConstBool_SyncService>() 
                        .Node<IY_OutConstBool_SyncService>(), 
                c => c.AddArg("simon", "args")
            )
            .If<IY_InInt_OutBool_SyncService>(
                b => b
                    .Then<IY_InBoolStr_OutConstInt_AsyncService>(c => c.RequireResult().AddArg("simon", "args"))
                    .Then<IY_InInt_OutBool_SyncService>(c => c.RequireResult())
                    .Pool<IY_InBool_OutBool_AsyncService, IY_InObjBool_OutStr_AsyncService, IY_InStr_AsyncService>(),
                b => b.Else<IService>(),
                c => c.RequireResult()
            );
```

Root -> Pool // this transition defines the type of node that Root is, and so, logically, Root cannot be defined ahead of time.



Internal representation:

    
