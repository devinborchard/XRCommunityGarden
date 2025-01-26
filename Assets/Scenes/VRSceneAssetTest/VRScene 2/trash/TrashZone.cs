using UnityEngine;
using Fusion;

public class TrashZone : MonoBehaviour
{

    [SerializeField]
    public NetworkMecanimAnimator grow;
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
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.Play();

            if (trash.Length - 1 == 0) {
              NetworkMecanimAnimator shrink = gameObject.GetComponentInParent<NetworkMecanimAnimator>();
              shrink.SetTrigger("ShrinkTrigger");
              Debug.Log("All Trash trashed");
              grow.SetTrigger("GrowTrigger");
            }

            
        }
    }
}
