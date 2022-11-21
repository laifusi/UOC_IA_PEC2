using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("MyActions/SetRandomFloat")]
[Help("Define a random float between two floats.")]
public class SetRandomFloat : BasePrimitiveAction
{
    [InParam("minFloat")]
    public float minFloat;

    [InParam("maxFloat")]
    public float maxFloat;

    [OutParam("randomFloat")]
    public float randomFloat;

    public override void OnStart()
    {
        randomFloat = Random.Range(minFloat, maxFloat);

        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }
}
