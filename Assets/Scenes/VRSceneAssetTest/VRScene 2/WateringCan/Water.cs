using UnityEngine;

public class Water : MonoBehaviour
{
    private float timeLived = 0f;
    private float maxTime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "gardenBed"){
           Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        timeLived = timeLived + Time.deltaTime;
        if(timeLived > maxTime){
            Destroy(gameObject);
        }
    }   
}
