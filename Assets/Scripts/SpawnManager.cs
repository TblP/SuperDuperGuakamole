using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] enemyOnMap;
    private float spawnRangeXp;
    private float spawnRangeXm;
    private float spawnRangeZu;
    private float spawnRangeZd;
    private float[] xp = { 75, 52, 52};
    private float[] xm = { 110,135,135};
    private float[] Zu = { 592,543,654};
    private float[] Zd = { 556, 495,605};

    private bool stopspawn = false;
    public Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        randomaiz();
        
    }

    // Update is called once per frame
    void Update()
    {

        enemyOnMap = GameObject.FindGameObjectsWithTag("Enemy");

        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        if (enemyOnMap.Length <= 2 && stopspawn == false)
        {
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
        if(stopspawn == false)
        {
            randomaiz();
        }
        if (enemyOnMap.Length == 2)
        {
            stopspawn = true;
        }
        
    }
    void randomaiz()
    {
        int pos = Random.Range(0,3);
        Debug.Log(pos);
        spawnRangeXp = xp[pos];
        spawnRangeXm = xm[pos];
        spawnRangeZd = Zd[pos];
        spawnRangeZu = Zu[pos];
        spawnPos = new Vector3(Random.Range(spawnRangeXp, spawnRangeXm), 290, Random.Range(spawnRangeZu, spawnRangeZd));
    }
    
}
