using UnityEngine;

public class Veggie : Plant
{
    Rigidbody rb;
    bool harvested = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool grav = rb.useGravity;
        if(readyForHarvest && grav == false && harvested){
            rb.useGravity = true;
        }
    }
}
