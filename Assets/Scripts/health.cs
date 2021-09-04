using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class health : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject plane;
    public Image bar;
    public Image backbar;
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
        if ( fill <= 0)
        {
            
            Destroy(gameObject);
            Destroy(backbar);
            Destroy(bar);

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
            fill -= 0.1f;
        }
        if (collision.gameObject.CompareTag("FloorEnemy"))
        {
           check = true;
        }
        if (collision.gameObject.CompareTag("EnemyAmmo"))
        {
            fill -= 0.2f;
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
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            fill -= 0.002f;
        }
    }

}
