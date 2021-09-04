using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceShoot : MonoBehaviour
{
    private float StartDelay = 2f;
    private float spawnInterval = 6f;
    public GameObject ammoPrefabs;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("spawn", StartDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawn()
    {
        //спаун области урона
        Instantiate(ammoPrefabs, Player.transform.position, transform.rotation);
    }
    
}
