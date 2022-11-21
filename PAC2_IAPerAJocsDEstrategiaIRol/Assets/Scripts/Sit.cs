using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;
using UnityEngine.AI;

[Action("MyActions/Sit")]
[Help("Sit in a given point.")]
public class Sit : BasePrimitiveAction
{
    [InParam("benchComponent")]
    public Bench benchComponent;

    [InParam("sittablePoint")]
    public Vector3 sittablePoint;

    [InParam("sittingDirection")]
    public Quaternion sittingDirection;

    [InParam("agent")]
    public NavMeshAgent agent;

    [InParam("sittableAgent")]
    public SittableAgent sittableAgent;

    public override TaskStatus OnUpdate()
    {
        agent.isStopped = true;
        agent.enabled = false;
        agent.transform.position = sittablePoint + new Vector3(0, agent.GetComponent<CapsuleCollider>().height/2, 0);
        agent.transform.rotation = sittingDirection;
        sittableAgent.IsSitting = true;
        benchComponent.IsOccupied = true;
        return TaskStatus.COMPLETED;
    }
}
