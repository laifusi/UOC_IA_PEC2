using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;
using UnityEngine.AI;

[Action("MyActions/MoveToPoint")]
[Help("Set NavMeshAgent's destination to the wanderPoint")]
public class MoveToPoint : BasePrimitiveAction
{
    [InParam("agent")]
    public NavMeshAgent agent;

    [InParam("point")]
    public Vector3 point;

    public override TaskStatus OnUpdate()
    {
        agent.SetDestination(point);
        return TaskStatus.COMPLETED;
    }
}
