using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;

    public TextMeshProUGUI gameOverText;

    public Button restart;

    public Button start;

    public Joystick jst;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    { 
        if(Player == null)
        {
            GameOver();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        jst.gameObject.SetActive(false);
        restart.gameObject.SetActive(true);
    }
    public void StartGame()
    { 
        Time.timeScale = 1;
        start.gameObject.SetActive(false);
    }
}
