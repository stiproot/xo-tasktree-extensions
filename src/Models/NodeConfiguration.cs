namespace Xo.TaskTree.Extensions.Builders;

public class NodeConfiguration : INodeConfiguration
{
    public bool RequiresResult { get; set; }
    public string? NextParamName{ get; set; }
    public IList<IMsg> Args{ get; set; } = new List<IMsg>();
}