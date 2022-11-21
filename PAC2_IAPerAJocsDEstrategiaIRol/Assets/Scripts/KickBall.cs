using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("MyActions/KickBall")]
[Help("Make the ball move to the other kid.")]
public class KickBall : BasePrimitiveAction
{
    [InParam("kidComponent")]
    public Kid kidComponent;

    [InParam("otherKid")]
    public Kid otherKid;

    [InParam("ball")]
    public Ball ball;

    public override TaskStatus OnUpdate()
    {
        if(kidComponent.ball == null)
        {
            ball = GameObject.Instantiate(kidComponent.ballPrefab, kidComponent.ballPosition.position, Quaternion.identity).GetComponent<Ball>();
            kidComponent.ball = ball;
            otherKid.ball = ball;
        }
        else
        {
            ball = kidComponent.ball;
        }

        bool reachedKid = ball.MoveToPosition(kidComponent.ballPosition.position, otherKid.ballPosition.position);
        if(reachedKid)
        {
            kidComponent.SetBallOnMe(false);
            otherKid.SetBallOnMe(true);
            return TaskStatus.COMPLETED;
        }
        else
        {
            return TaskStatus.RUNNING;
        }
    }
}
