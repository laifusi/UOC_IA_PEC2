using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/IsSitting")]
[Help("Check if the agent is sitting")]
public class IsSitting : ConditionBase
{
    [InParam("sittableAgent")]
    public SittableAgent sittableAgent;

    public override bool Check()
    {
        return sittableAgent.IsSitting;
    }
}
