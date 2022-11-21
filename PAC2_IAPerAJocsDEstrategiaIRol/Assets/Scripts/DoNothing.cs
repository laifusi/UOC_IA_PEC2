using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;

[Action("MyActions/DoNothing")]
[Help("Do nothing.")]
public class DoNothing : BasePrimitiveAction
{
    public override TaskStatus OnUpdate()
    {
        return TaskStatus.SUSPENDED;
    }
}