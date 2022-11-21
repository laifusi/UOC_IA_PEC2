using Pada1.BBCore;
using Pada1.BBCore.Framework;
using UnityEngine;

[Condition("MyConditions/IsWaitTimeOver")]
[Help("Check if the wait time is over.")]
public class IsWaitTimeOver : ConditionBase
{
    [InParam("waitTime")]
    public float waitTime;

    public override bool Check()
    {
        return Time.unscaledTime >= waitTime;
    }
}
