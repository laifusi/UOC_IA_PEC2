using UnityEngine;

public class FlockManager : MonoBehaviour
{
    [SerializeField] GameObject prefab; //flock prefab
    [SerializeField] int numberOfAnimals = 20; //number of flocks
    [SerializeField] Vector3 instantiationLimits = new Vector3(1, 1, 1); //limits of instantiation
    
    public Vector3 movementLimits = new Vector3(5, 5, 5); //movement limits for the flocks
    public GameObject[] allAnimals; //array of all the flocks
    public Vector3 goalPosition; //goal point

    [Range(0, 5)] public float minSpeed; //minimum speed
    [Range(1, 10)] public float maxSpeed; //maximum speed
    [Range(1, 10)] public float neighbourDistance; //maximum distance to neighbours to consider
    [Range(0, 5)] public float rotationSpeed; //rotation speed

    /// <summary>
    /// We instantiate the given number of flocks in a random position inside the instantiation limits
    /// </summary>
    private void Start()
    {
        allAnimals = new GameObject[numberOfAnimals];
        for(int i = 0; i < numberOfAnimals; i++)
        {
            float x = Random.Range(-instantiationLimits.x, instantiationLimits.x);
            float y = Random.Range(-instantiationLimits.y, instantiationLimits.y);
            float z = Random.Range(-instantiationLimits.z, instantiationLimits.z);
            Vector3 pos = transform.position + new Vector3(x, y, z);
            allAnimals[i] = Instantiate(prefab, pos, Quaternion.identity);
            allAnimals[i].GetComponent<Flock>().myManager = this;
        }

        goalPosition = transform.position;
    }

    /// <summary>
    /// We update the goal point to a random position inside the instatiation limits
    /// </summary>
    private void Update()
    {
        if(Random.Range(0, 100) < 10)
        {
            float x = Random.Range(-instantiationLimits.x, instantiationLimits.x);
            float y = Random.Range(-instantiationLimits.y, instantiationLimits.y);
            float z = Random.Range(-instantiationLimits.z, instantiationLimits.z);
            goalPosition = transform.position + new Vector3(x, y, z);
        }
    }
}
