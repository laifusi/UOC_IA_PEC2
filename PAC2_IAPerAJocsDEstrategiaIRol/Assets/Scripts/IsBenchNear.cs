using BBUnity.Conditions;
using Pada1.BBCore;
using UnityEngine;

[Condition("MyConditions/IsBenchNear")]
[Help("Check if a Bench is in sight.")]
public class IsBenchNear : GOCondition
{
    [InParam("checkRadius")]
    public float checkRadius;

    [InParam("perceptionAngle")]
    public int perceptionAngle;

    [InParam("benchMask")]
    public LayerMask benchMask;

    [InParam("obstacleMask")]
    public LayerMask obstacleMask;

    [OutParam("benchComponent")]
    public Bench benchComponent;

    [OutParam("benchPosition")]
    public Vector3 benchWalkPosition;

    [OutParam("benchSittablePosition")]
    public Vector3 benchSitPosition;

    [OutParam("benchSittingDirection")]
    public Quaternion benchSitDirection;

    public override bool Check()
    {
        Transform transform = gameObject.transform;
        Collider[] benchesInPerceptionRadius = Physics.OverlapSphere(transform.position, checkRadius, benchMask);
        for (int i = 0; i < benchesInPerceptionRadius.Length; i++)
        {
            Transform bench = benchesInPerceptionRadius[i].transform;
            Vector3 direction = (bench.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, direction) <= perceptionAngle / 2)
            {
                float distance = Vector3.Distance(transform.position, bench.position);
                if (!Physics.Raycast(transform.position, direction, distance, obstacleMask))
                {
                    benchComponent = bench.GetComponent<Bench>();
                    if (!benchComponent.IsOccupied)
                    {
                        benchWalkPosition = benchComponent.WalkPosition.position;
                        benchSitPosition = benchComponent.SitPosition.position;
                        benchSitDirection = benchComponent.SitPosition.rotation;
                        return true;
                    }
                    else if(gameObject.transform.position == benchComponent.SitPosition.position + new Vector3(0, gameObject.GetComponent<CapsuleCollider>().height/2, 0))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
