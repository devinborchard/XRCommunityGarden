using UnityEngine;

public class Fruit : Plant
{
    public GameObject fruit;
    public GameObject[] fruitSpawns;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void GrowFruit(){
        for(int i = 0; i < fruitSpawns.Length; i++){

            GameObject fruitPlace = fruitSpawns[i];

            bool fruitPresent = false;
            foreach (Transform child in fruitPlace.transform)
            {
                fruitPresent = true;
            }

            if(!fruitPresent){
                GameObject newFruit = Instantiate(fruit);
                // newFruit.transform.position = fruitPlace.transform.position;
                // newFruit.transform.SetParent(fruitPlace.transform, false);
                // Set the newFruit's position to match the parent's position
                // newFruit.transform.localPosition = Vector3.zero;
                newFruit.transform.position = fruitPlace.transform.position;

                // (Optional) If you want it to also match the parent's rotation
                // newFruit.transform.localRotation = Quaternion.identity;
            }
        }
        updated = true;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
