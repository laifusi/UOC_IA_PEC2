using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockManager myManager; //FlockManager

    private float speed; //speed of the flock
    private bool turning; //bool to indicate if we are turning or not

    /// <summary>
    /// We initialize a random speed
    /// </summary>
    private void Start()
    {
        speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
    }

    /// <summary>
    /// We update the flock's position in each frame,
    /// making sure we are not out of bounds,
    /// resetting the speed and applying the flocking rules at random times
    /// </summary>
    private void Update()
    {
        Bounds bounds = new Bounds(myManager.transform.position, myManager.movementLimits * 2);
        Vector3 direction = Vector3.zero;

        if (!bounds.Contains(transform.position))
        {
            turning = true;
        }
        else
        {
            turning = false;
        }

        if (turning)
        {
            direction = myManager.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);
        }
        else
        {
            if (Random.Range(0, 100) < 10)
                speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);

            if (Random.Range(0, 100) < 20)
                ApplyRules();
        }

        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    /// <summary>
    /// Method to apply the flocking rules of cohesion, alignment and separation
    /// </summary>
    private void ApplyRules()
    {
        GameObject[] allNeighbours = myManager.allAnimals;
        Vector3 center = Vector3.zero;
        Vector3 avoid = Vector3.zero;
        float globalSpeed = 0.01f;
        float neighbourDistance;
        int groupSize = 0;

        foreach(GameObject neighbour in allNeighbours)
        {
            if(neighbour != gameObject)
            {
                neighbourDistance = Vector3.Distance(neighbour.transform.position, transform.position);
                if(neighbourDistance <= myManager.neighbourDistance)
                {
                    center += neighbour.transform.position;
                    groupSize++;

                    if(neighbourDistance < 1)
                    {
                        avoid += transform.position - neighbour.transform.position;
                    }

                    Flock neighbourFlock = neighbour.GetComponent<Flock>();
                    globalSpeed += neighbourFlock.speed;
                }
            }
        }

        if(groupSize > 0)
        {
            center = center / groupSize + myManager.goalPosition - transform.position;
            speed = globalSpeed / groupSize;

            Vector3 direction = center + avoid - transform.position;
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);
            }
        }
    }
}
