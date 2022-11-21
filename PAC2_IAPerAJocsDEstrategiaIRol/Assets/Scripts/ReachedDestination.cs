using BBUnity.Conditions;
using Pada1.BBCore;
using UnityEngine.AI;

[Condition("MyConditions/ReachedDestination")]
[Help("Check if a NavMeshAgent reached its destination.")]
public class ReachedDestination : GOCondition
{
    [InParam("agent")]
    public NavMeshAgent navMeshAgent;

    [InParam("checkDistance")]
    public float checkDistance;

    public override bool Check()
    {
        return navMeshAgent.remainingDistance < checkDistance;
    }
}
