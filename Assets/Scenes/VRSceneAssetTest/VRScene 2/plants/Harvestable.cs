using UnityEngine;

public class Harvestable : MonoBehaviour
{
    public bool stored = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void RemoveStored(){
        stored = false;
    }

    public bool IsStored(){
        return stored;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("harvestable"))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the specified tag
        if (other.CompareTag("basket"))
        {
            Destroy(gameObject);
            
            // Add your custom logic here
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
