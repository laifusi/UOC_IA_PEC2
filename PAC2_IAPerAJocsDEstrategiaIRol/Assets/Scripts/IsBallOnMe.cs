using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/IsBallOnMe")]
[Help("Check if the kid has the ball")]
public class IsBallOnMe : ConditionBase
{
    [InParam("kidComponent")]
    public Kid kidComponent;

    public override bool Check()
    {
        return kidComponent.IsBallOnMe;
    }
}
