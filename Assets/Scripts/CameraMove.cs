using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    public Joystick joystick;
    public float speed = 10.0f;
    public float verticalInput;
    private Rigidbody cameraRb;
    public float upBound;
    public float downBound;
    // Start is called before the first frame update
    void Start()
    {
        cameraRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        verticalInput = joystick.Vertical;
        cameraRb.velocity = new Vector3(cameraRb.velocity.z, joystick.Vertical * speed);

        if (transform.position.y > upBound)
        {
            transform.position = new Vector3(transform.position.x, upBound, transform.position.z);
        }

        if (transform.position.y < downBound)
        {
            transform.position = new Vector3(transform.position.x, downBound, transform.position.z);
        }

    }
}
