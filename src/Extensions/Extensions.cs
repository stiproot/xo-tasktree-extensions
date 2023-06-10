namespace Xo.TaskTree.Extensions.Reflection;

public static class TypeExtensions
{
    public static Type ServiceType(this Expression<Action<IFlowBuilder>> @this)
    {
        return GetGenericType(@this);
    }

    public static Type GetGenericTypeParameter(this Type @this)
    {
        return @this.GenericTypeArguments.First();
    }

    public static Type GetGenericType(Expression<Action<IFlowBuilder>> builder)
    {
        MethodCallExpression methodCallExpression = (MethodCallExpression)builder.Body;

        MethodInfo methodType = methodCallExpression.Method;

        Type genericArgument = methodType.GetGenericArguments().First();

        return genericArgument;
    }

    public static Action<INodeConfigurationBuilder> GetLambdaExpr(Expression expr)
    {
        return expr switch
        {
            UnaryExpression _expr => GetLambdaExpr(_expr.Operand),
            LambdaExpression _expr => _expr.Compile() as Action<INodeConfigurationBuilder>, 
            _ => throw new NotSupportedException()
        };
    }
}