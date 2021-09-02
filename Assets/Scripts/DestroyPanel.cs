using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPanel : MonoBehaviour
{
    private float StartDelay = 3f;
    private float spawnInterval = 4f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y-3.5f, transform.position.z);
        InvokeRepeating("Destroy", StartDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
