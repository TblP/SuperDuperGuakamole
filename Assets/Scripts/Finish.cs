using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour
{
    public TextMeshProUGUI CompleteLvl;
    public Joystick jst;
    public Button restart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("lvl complete!!!");
            CompleteLvl.gameObject.SetActive(true);
            jst.gameObject.SetActive(false);
            restart.gameObject.SetActive(true);
        }
    }
}
