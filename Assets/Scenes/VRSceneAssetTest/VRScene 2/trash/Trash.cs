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
            GameObject[] trash = GameObject.FindGameObjectsWithTag("trash");
            if (trash.Length - 1 == 0) {
              Debug.Log("All Trash trashed");
            }
            
            Trashed();
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
