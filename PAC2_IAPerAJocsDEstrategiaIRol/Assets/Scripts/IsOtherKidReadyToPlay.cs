using BBUnity.Conditions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Condition("MyConditions/IsOtherKidReadyToPlay")]
[Help("Check if another Kid is ready to play")]
public class IsOtherKidReadyToPlay : GOCondition
{
    [OutParam("otherKid")]
    public Kid otherKid;

    public override bool Check()
    {
        if(SearchOtherKid())
        {
            return otherKid.IsReadyToPlay;
        }
        else
        {
            return false;
        }
    }

    private bool SearchOtherKid()
    {
        bool kidFound = false;
        Kid[] kidsInScene = GameObject.FindObjectsOfType<Kid>();
        for(int i = 0; i < kidsInScene.Length; i++)
        {
            if(kidsInScene[i].gameObject != gameObject)
            {
                kidFound = true;
                otherKid = kidsInScene[i];
            }
        }

        return kidFound;
    }

    public override TaskStatus MonitorFailWhenFalse()
    {
        if (!Check())
            return TaskStatus.FAILED;
        else
        {
            otherKid.OnChangedReady += OtherKidReady;
            return TaskStatus.SUSPENDED;
        }
    }

    private void OtherKidReady()
    {
        otherKid.OnChangedReady -= OtherKidReady;
        EndMonitorWithFailure();
    }
}
