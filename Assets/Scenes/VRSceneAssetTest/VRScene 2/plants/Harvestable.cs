using UnityEngine;

public class Harvestable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("harvestable"))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
