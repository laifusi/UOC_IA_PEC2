using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public float timePassed; //time passed since the start

    /// <summary>
    /// We update the time passed every frame
    /// </summary>
    private void Update()
    {
        timePassed += Time.deltaTime;
    }
}
