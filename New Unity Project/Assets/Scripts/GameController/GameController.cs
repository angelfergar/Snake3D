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

	// Use this for initialization
	void Start () {

        playText.text = "PLAY";
        //Al pular el botón, empieza el juego
        Button btn1 = playButton.GetComponent<Button>();
        btn1.onClick.AddListener(StartGame);
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
    }

    public void SetCountText() //Para llevar la cuenta 
    {
        countText.text = count.ToString();
    }
}
