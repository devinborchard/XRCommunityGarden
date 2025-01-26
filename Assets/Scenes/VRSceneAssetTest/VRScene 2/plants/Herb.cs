using UnityEngine;
using System.Collections.Generic;  // Add this to use List<>

public class Herb : Plant
{
    public string herbName;


    GameObject GetFromStorage(GameObject[] allObjects){
        foreach (GameObject obj in allObjects)
        {
            if (obj.name.Contains(herbName) && !obj.activeSelf)
            {
                obj.SetActive(true);
                obj.GetComponent<Harvestable>().RemoveStored();
                return obj;
            }
        }
        
        // foreach (GameObject obj in allObjects)
        // {
        //     if (obj.name.Contains(herbName) && obj.GetComponent<Harvestable>().IsStored())
        //     {
        //         obj.GetComponent<Harvestable>().RemoveStored();
        //         return obj;
        //     }
        // }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        if(readyForHarvest){

            GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            List<GameObject> result = new List<GameObject>();

            foreach (var rootObject in rootObjects)
            {
                // Traverse all child objects (including inactive ones)
                Transform[] allTransforms = rootObject.GetComponentsInChildren<Transform>(true);
                foreach (var t in allTransforms)
                {
                    if (t.CompareTag("harvestable"))
                    {
                        result.Add(t.gameObject);
                    }
                }
            }

            GameObject[] result1 = result.ToArray();


            // GameObject[] allObjects = GameObject.FindGameObjectsWithTag("harvestable");
            GameObject obj = GetFromStorage(result1);

            obj.transform.position = gameObject.transform.position;

            Destroy(gameObject);
        }
    }
}
