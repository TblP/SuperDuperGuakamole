using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public Image bar;
    public float fill;
    private float StartDelay = 2;
    private float spawnInterval = 1.0f;
    private bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        fill = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = fill;
        if ( fill < 0)
        {
            Debug.Log("GameOver");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           fill -= 0.2f;
        }
    }
    
}
