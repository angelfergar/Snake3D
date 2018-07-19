using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	// Use this for initialization
	void Start () {

        playText.text = "PLAY";
        pauseText.text = "";
        //Al pulsar el botón, empieza el juego
        Button btn1 = playButton.GetComponent<Button>();
        Button btn2 = pauseButton.GetComponent<Button>();
        Button btn3 = resumeButton.GetComponent<Button>();
        btn1.onClick.AddListener(StartGame);
        btn2.onClick.AddListener(PauseGame);
        btn3.onClick.AddListener(ResumeGame);
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
}
