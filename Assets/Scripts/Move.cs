using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float rightBound = 135;
    public float leftBound = 52;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    private Rigidbody playerRb;
    public Joystick joystick;
    private float StartDelay = 0.2f;
    private float spawnInterval = 0.5f;
    public GameObject ammoPrefabs;
    public Transform shotDir;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        InvokeRepeating("shoots",StartDelay,spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {

        verticalInput = joystick.Vertical;
        horizontalInput = joystick.Horizontal;
        //передвижение
        playerRb.velocity = new Vector3(joystick.Horizontal * speed,playerRb.velocity.z, joystick.Vertical * speed);
        
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(playerRb.velocity);
        }

        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
        //границы экрана
        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }

    }   
    
        void shoots()
    {
        //стрельба
        if (verticalInput == 0 && horizontalInput == 0)
        {
            Instantiate(ammoPrefabs, shotDir.transform.position, transform.rotation);
        }
    }

}
