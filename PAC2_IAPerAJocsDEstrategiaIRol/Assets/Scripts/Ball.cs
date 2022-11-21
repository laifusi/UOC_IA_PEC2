using UnityEngine;

public class Ball : MonoBehaviour
{
    float time; //time since the ball started moving
    float timeToTarget = 2; //time to reach the target

    /// <summary>
    /// We randomize the first timeToTarget
    /// </summary>
    private void Start()
    {
        timeToTarget = Random.Range(0.5f, 2f);
    }

    /// <summary>
    /// Method to move the ball from a position to another
    /// This method will be called until it reaches the target
    /// </summary>
    /// <param name="startPosition">initial position</param>
    /// <param name="targetPosition">target position</param>
    /// <returns>true if we reached the target, false if we didn't</returns>
    public bool MoveToPosition(Vector3 startPosition, Vector3 targetPosition)
    {
        time += Time.deltaTime/timeToTarget;
        transform.position = Vector3.Lerp(startPosition, targetPosition, time);
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            time = 0;
            timeToTarget = Random.Range(0.5f, 2f);
            return true;
        }
        else
        {
            return false;
        }
    }
}
