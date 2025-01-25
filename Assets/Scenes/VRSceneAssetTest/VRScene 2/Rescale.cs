using UnityEngine;

public class Rescale : MonoBehaviour
{
    public float modifier = 1f;
    void Awake()
    {
        float gameScale = GameObject.Find("gameTransform").transform.localScale.x * modifier;
        transform.localScale = new Vector3(gameScale, gameScale, gameScale);
    }
    
}
