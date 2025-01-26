using UnityEngine;

public class Cucumber : Fruit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"READY: {readyForHarvest}");
        // Debug.Log($"UPDATED: {updated}");
        if(readyForHarvest && updated == false && Watered()){
            // Debug.Log("GROW FURUIT");
            GrowFruit();
        }
    }
}
