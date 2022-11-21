using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;

[Action("MyActions/SetKidReadyToPlay")]
[Help("Set the kid's ready to play bool to true.")]
public class SetKidReadyToPlay : BasePrimitiveAction
{
    [InParam("kidComponent")]
    public Kid kidComponent;

    public override TaskStatus OnUpdate()
    {
        kidComponent.SetIsReadyToPlay(true);
        return TaskStatus.COMPLETED;
    }
}
