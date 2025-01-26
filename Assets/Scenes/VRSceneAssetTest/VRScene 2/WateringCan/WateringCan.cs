using UnityEngine;

public class WateringCan : MonoBehaviour
{
    public GameObject waterSpawnPoint;
    public GameObject waterSpawnDirection;
    public GameObject water;

    private bool watering = false;
    
    public float maxRandomWaterSpeed = 0.05f;

    public float waterInitialSpeed = 1f;

    public Vector3 minScale = new Vector3(0.8f, 0.8f, 0.8f); // Minimum scale
    public Vector3 maxScale = new Vector3(1.5f, 1.5f, 1.5f); // Maximum scale

    AudioSource audio = gameObject.GetComponent<AudioSource>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Watering(){
        GameObject newWater = Instantiate(water);
        newWater.transform.position = waterSpawnPoint.transform.position;

        // Get the Rigidbody component
        Rigidbody rb = newWater.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Generate a random velocity
            Vector3 randomVelocity = new Vector3(
                Random.Range(-maxRandomWaterSpeed, maxRandomWaterSpeed),
                Random.Range(-maxRandomWaterSpeed, maxRandomWaterSpeed*3),
                Random.Range(-maxRandomWaterSpeed, maxRandomWaterSpeed)
            );

            Vector3 direction = (waterSpawnDirection.transform.position - waterSpawnPoint.transform.position).normalized;

            // Calculate the velocity in the direction of the target
            Vector3 initialVelocity = direction * waterInitialSpeed;

            // Apply the random velocity to the Rigidbody
            rb.linearVelocity = randomVelocity + initialVelocity;

            // float randomX = Random.Range(minScale.x, maxScale.x);
            // float randomY = Random.Range(minScale.y, maxScale.y);
            // float randomZ = Random.Range(minScale.z, maxScale.z);

            // // Apply the random scale to the GameObject
            // transform.localScale = new Vector3(randomX, randomY, randomZ);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(waterSpawnPoint.transform.position.y < gameObject.transform.position.y && watering == false){
            watering = true;
        }
        if(waterSpawnPoint.transform.position.y > gameObject.transform.position.y && watering == true){
            watering = false;
        }

        if(watering){
            Watering();
            audio.Play();
        } else {
            audio.Stop();
        }
    }
}
