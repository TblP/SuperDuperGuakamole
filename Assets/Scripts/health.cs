using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public GameObject plane;
    public Image bar;
    public float fill;
    bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        fill = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        plane = GameObject.FindWithTag("FloorEnemy");
        
        bar.fillAmount = fill;
        if ( fill < 0)
        {
            Debug.Log("GameOver");
        }

        if (check == true && plane != null)
        {
            fill -= 0.001f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
           fill -= 0.2f;
        }

        if (collision.gameObject.CompareTag("FloorEnemy"))
        {
           check = true;
        }
        if (collision.gameObject.CompareTag("EnemyAmmo"))
        {

            Debug.Log("123");
            fill -= 0.3f;
            Destroy(collision.gameObject);

        }

    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("FloorEnemy"))
        {
           check = false;
        }
    }
}
