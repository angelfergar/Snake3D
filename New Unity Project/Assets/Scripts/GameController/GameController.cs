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
    public Text restartText;
    public Text scoreText;
    public Text finalCountText;
    public Image cubeScore;

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
        cubeScore.gameObject.SetActive(false);
        playText.text = "PLAY";
        pauseText.text = "";
        scoreText.text = "";
        finalCountText.text = "";
        restartText.text = "";
        countText.text = "";
        playButton.gameObject.SetActive(true);
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
        Time.timeScale = 1.0f;
        playText.text = "";
        playButton.gameObject.SetActive(false);
        countText.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        cubeScore.gameObject.SetActive(true);


    }

    void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pauseText.text = "";
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }

    void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseText.text = "PAUSE";
        playButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);

    }

    public void SetCountText() //Para llevar la cuenta 
    {
        countText.text = count.ToString();
    }

    public void Dead()
    {
        restartText.text = "RESTART";
        scoreText.text = "YOUR SCORE";
        finalCountText.text = count.ToString();
        countText.text = "";
        playButton.gameObject.SetActive(false);
        cubeScore.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        Time.timeScale = 0.0f;
    }

    void RestartGame()
    {
        
        SceneManager.LoadScene("MainScene"); //Carga de nuevo la escena principal
    }
}
