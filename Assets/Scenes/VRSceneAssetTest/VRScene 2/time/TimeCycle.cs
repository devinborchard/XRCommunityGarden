using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    float time = 0;
    public float timeForDay = 10f;
    float timeOfDay = 0;
    int day = 0;

    public GameObject lightSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void GrowPlant(GameObject plant){
        Plant plantScript = plant.GetComponent<Plant>();
        if(plantScript.Watered()){
            plantScript.nextStage();
            plantScript.RenderStage();
            plantScript.ResetUpdate();
        }
    }

    void GrowSeed(GameObject seed){
        Seed seedScript = seed.GetComponent<Seed>();
        if(seedScript.Watered() && seedScript.Planted()){
            seedScript.Grow();
            Destroy(seed);
        }
    }

    void NewDay(){
        // Debug.Log("new Day");
        GameObject[] plants = GameObject.FindGameObjectsWithTag("plant");
        for(int i = 0; i < plants.Length; i++){
            GrowPlant(plants[i]);
        }

        GameObject[] seeds = GameObject.FindGameObjectsWithTag("seed");
        for(int i = 0; i < seeds.Length; i++){
            GrowSeed(seeds[i]);
        }
    }

    void UpdateLight(){
        float percentOfDay = timeOfDay/timeForDay;
        float lightAngle = percentOfDay*360;

        Vector3 currentRotation = transform.eulerAngles;
        lightSource.transform.eulerAngles = new Vector3(lightAngle, currentRotation.y, currentRotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        timeOfDay = timeOfDay + Time.deltaTime;

        UpdateLight();

        if(timeOfDay > timeForDay){
            timeOfDay = 0;
            day = day + 1;
            NewDay();
        }


    }
}
