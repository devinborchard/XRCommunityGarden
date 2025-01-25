using UnityEngine;

public class Seed : MonoBehaviour
{

    public GameObject plantObject;
    private bool watered = false;
    private bool planted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Water(){
        watered = true;
    }

    public bool Watered(){
        return watered;
    }

    public bool Planted(){
        return planted;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Log the name of the object this GameObject collided with
        // Debug.Log($"Collided with {collision.gameObject.name}");
        if (collision.gameObject.tag == "water"){
            Water();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is tagged as "Player"
        if (other.CompareTag("plantable"))
        {
            planted = true;
        }
    }

    public GameObject Grow(){
        GameObject newPlant = Instantiate(plantObject);
        newPlant.transform.position = gameObject.transform.position;
        Plant plantScript = newPlant.GetComponent<Plant>();
        plantScript.RenderStage();
        return newPlant;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
