using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAmmo : MonoBehaviour
{
    private float topBound = 700;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FWell") || other.gameObject.CompareTag("Bounds"))
        {
            
            Destroy(gameObject);
        }

    }

}
