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
    public bool ForwardCheck = false;
    public bool BackCheck = false;
    public bool LeftCheck = false;
    public bool RightCheck = false;
    public bool BoundCheck = false;
    private float StartDelay = 2;
    private float spawnInterval = 1.0f;
    
    public GameObject ammoPrefabs;
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

        playerRb.velocity = new Vector3(joystick.Horizontal * speed,playerRb.velocity.z, joystick.Vertical * speed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(playerRb.velocity);
        }

        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);

        }

        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }

        /*/
        if (verticalInput < 0 && verticalInput > -1 && BackCheck == false)
        {
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
            Debug.Log("Back");
        }
        else if (verticalInput > 0 && verticalInput < 1 && ForwardCheck == false)
        {
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
            Debug.Log("Forward"); 
        }
        if ( horizontalInput < 0 && horizontalInput > -1 && LeftCheck == false)
        {
            Debug.Log("Left");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        }else if (horizontalInput > 0 && horizontalInput < 1 && RightCheck == false)
        {
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            Debug.Log("Right");
        }
        

        
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FWell") && verticalInput < 0 && verticalInput > -1)
        {
            Debug.Log("FBWell");
            BackCheck = true;

        }else if (collision.gameObject.CompareTag("FWell") && verticalInput > 0 && verticalInput < 1)
        {
            Debug.Log("FFWell");
            ForwardCheck = true;
        }
        if (collision.gameObject.CompareTag("FWell") && horizontalInput < 0 && horizontalInput > -1)
        {
            Debug.Log("FRWell");
            LeftCheck = true;
        }else if (collision.gameObject.CompareTag("FWell") && horizontalInput > 0 && horizontalInput < 1)
        {
            Debug.Log("FLWell");
            RightCheck = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("FWell") && verticalInput > 0 && verticalInput < 1)
        {
            Debug.Log("FBWellEx");
            BackCheck = false;
            LeftCheck = false;
            RightCheck = false;
        }
        else if (collision.gameObject.CompareTag("FWell") && verticalInput < 0 && verticalInput > -1)
        {
            Debug.Log("FFWellEx");
            ForwardCheck = false;
            LeftCheck = false;
            RightCheck = false;
        }
        if (collision.gameObject.CompareTag("FWell") && horizontalInput > 0 && horizontalInput < 1)
        {
            Debug.Log("FLWell");
            LeftCheck = false;
            ForwardCheck = false;
            BackCheck = false;

        }
        else if (collision.gameObject.CompareTag("FWell") && horizontalInput < 0 && horizontalInput > -1)
        {
            Debug.Log("FRWell");
            RightCheck = false;
            ForwardCheck = false;
            BackCheck = false;
        }/*/
    }   
    
        void shoots()
    {
        if (verticalInput == 0 && horizontalInput == 0)
        {
            Instantiate(ammoPrefabs, transform.position, ammoPrefabs.transform.rotation);
        }
    }
}
