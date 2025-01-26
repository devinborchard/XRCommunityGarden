using UnityEngine;

public class TrashZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("trash"))
        {
            GameObject[] trash = GameObject.FindGameObjectsWithTag("trash");
            if (trash.Length - 1 == 0) {
              Debug.Log("All Trash trashed");
            }

            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
