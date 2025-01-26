using UnityEngine;
using Oculus.Interaction;
using System.Collections.Generic;  // Add this to use List<>

public class Fruit : Plant
{
    public GameObject[] fruitSpawns;
    public string fruitName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    GameObject GetFromStorage(GameObject[] allObjects){
        foreach (GameObject obj in allObjects)
        {
            if (obj.name.Contains(fruitName)&& !obj.activeSelf)
            {
                obj.SetActive(true);
                obj.GetComponent<Harvestable>().RemoveStored();
                return obj;
            }
        }
        return null;
    }

    bool SpawnOpen(GameObject fruitPlace, GameObject[] allObjects){
        Vector3 position = fruitPlace.transform.position;

        bool taken = false;
        for(int i = 0; i < allObjects.Length; i++){
            if(allObjects[i].transform.position == position){
                taken = true;
            }
        }
        return !taken;
    }

    public void GrowFruit(){

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
        
        for(int i = 0; i < fruitSpawns.Length; i++){
            GameObject fruitPlace = fruitSpawns[i];

            if(SpawnOpen(fruitPlace, result1)){
                GameObject fruitFound = GetFromStorage(result1);
                fruitFound.transform.position = fruitPlace.transform.position;
                fruitFound.transform.rotation = fruitPlace.transform.rotation;
            }
        }
        updated = true;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
