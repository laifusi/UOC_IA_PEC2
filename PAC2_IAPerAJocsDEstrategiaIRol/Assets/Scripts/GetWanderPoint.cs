using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;
using UnityEngine.AI;

[Action("MyActions/GetWanderPoint")]
[Help("Calculate the wander point.")]
public class GetWanderPoint : BasePrimitiveAction
{
    [InParam("wanderDistance")]
    public int wanderDistance;

    [InParam("wanderRadius")]
    public int wanderRadius;

    [InParam("agent")]
    public NavMeshAgent navMeshAgent;

    private Vector3 center;
    private float randomAngle;

    [OutParam("wanderPoint")]
    public Vector3 wanderPoint;

    public override TaskStatus OnUpdate()
    {
        center = navMeshAgent.transform.position + navMeshAgent.velocity.normalized * wanderDistance;
        randomAngle = Random.Range(0f, 2 * Mathf.PI);
        Vector3 direction = new Vector3(Mathf.Sin(randomAngle), 0, Mathf.Cos(randomAngle));
        wanderPoint = center + direction * wanderRadius;
        return TaskStatus.COMPLETED;
    }
}
