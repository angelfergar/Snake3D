using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject snake;
    public Text playText;
    public bool empezado;
    public Button playButton;

	// Use this for initialization
	void Start () {

        playText.text = "PLAY";
        //Al pular el botón, empieza el juego
        Button btn1 = playButton.GetComponent<Button>();
        btn1.onClick.AddListener(StartGame);
            

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartGame()
    {
        empezado = true;
        playText.text = "";
    }
}
