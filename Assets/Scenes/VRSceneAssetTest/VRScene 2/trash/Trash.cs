using UnityEngine;

public class Trash : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("trashZone"))
        {
            Trashed();
        }
    }

    void Trashed(){
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
