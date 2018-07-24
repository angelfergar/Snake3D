using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject snake;
    public Text playText;
    public bool empezado;
    public Button playButton;
    public int count; //Lo que vale cada PickUp
    public Text countText;
    public Button pauseButton;
    public Text pauseText;
    public Button resumeButton;
    public Button restartButton;

	// Use this for initialization
	void Start () {

        //Botones
        Button btn1 = playButton.GetComponent<Button>();
        Button btn2 = pauseButton.GetComponent<Button>();
        Button btn3 = resumeButton.GetComponent<Button>();
        Button btn4 = restartButton.GetComponent<Button>();
        //Llamadas a funciones
        btn1.onClick.AddListener(StartGame);
        btn2.onClick.AddListener(PauseGame);
        btn3.onClick.AddListener(ResumeGame);
        btn4.onClick.AddListener(RestartGame);
        //Estado inicial
        playText.text = "PLAY";
        pauseText.text = "";
        restartButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        count = 0;
        SetCountText();
      
        
            

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartGame()
    {
        empezado = true;
        playText.text = "";
        pauseButton.gameObject.SetActive(true);
        
        
    }

    void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pauseText.text = "";
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }

    void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseText.text = "PAUSE";
        resumeButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);

    }

    public void SetCountText() //Para llevar la cuenta 
    {
        countText.text = count.ToString();
    }

    public void Dead()
    {
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        empezado = false;
    }

    void RestartGame()
    {
        
        SceneManager.LoadScene("MainScene"); //Carga de nuevo la escena principal
    }
}
