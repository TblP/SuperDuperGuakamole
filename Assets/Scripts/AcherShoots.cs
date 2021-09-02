using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcherShoots : MonoBehaviour
{
    private float StartDelay = 1f;
    private float spawnInterval = 3f;
    public GameObject ammoPrefab;
    public Transform shotD;
    bool check = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoots", StartDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.CompareTag("Player") == true)
        {
            check = false;
        }
        
    }
    void shoots()
    {

        //סענוכüבא
        if (check == true)
        {
            Instantiate(ammoPrefab, shotD.transform.position, transform.rotation);
        }
    }
}
