using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 40.0f;
    public Vector3 y;
    private GameObject hand;
    private Rigidbody ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hand = GameObject.FindWithTag("Player");
        y = hand.transform.position;
        //Debug.Log(y);
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    
}
