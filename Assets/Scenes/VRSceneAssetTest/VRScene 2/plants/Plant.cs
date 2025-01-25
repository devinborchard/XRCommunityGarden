using UnityEngine;

public class Plant : MonoBehaviour
{

    public int ageInHours = 0;
    public int stage = 0;
    public bool readyForHarvest = false;
    public GameObject[] stages;
    public bool updated = false;


    private bool watered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RenderStage();
    }

    public void RenderStage()
    {
        // Debug.Log($"{stages.Length}");

        for(int i = 0; i < stages.Length; i++){
            GameObject stageObject = stages[i];
            if(i == stage){
                //enable
                stageObject.SetActive(true);
            }
            else{
                //disable
                stageObject.SetActive(false);
            }
        }
    }

    public bool Watered(){
        return watered;
    }
    public void Water(){
        watered = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Log the name of the object this GameObject collided with
        // Debug.Log($"Collided with {collision.gameObject.name}");
        if (collision.gameObject.tag == "water"){
            Water();
        }

    }

    public void ResetUpdate(){
        updated = false;
    }

    public void nextStage(){
        if(stage < stages.Length-1){
            stage = stage + 1;
            watered = false;
        }
        else{
            readyForHarvest = true;
        }
    }

    public void setStage(int stageValue){
        stage = stageValue;
        watered = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
