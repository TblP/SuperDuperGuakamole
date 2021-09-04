using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyAmmo : MonoBehaviour
{
    private float topBound = 700;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FWell") || collision.gameObject.CompareTag("Bounds"))
        {

            Destroy(gameObject);
        }
    }
}

