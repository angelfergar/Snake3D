using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject snake;
    public bool empezado;
    public int count;
    [Header("UI")]
    public Text playText;
    public Button playButton;
    //Lo que vale cada PickUp
    public Text countText;
    public Button pauseButton;
    public Text pauseText;
    public Button resumeButton;
    public Button restartButton;
    public Text restartText;
    public Text scoreText;
    public Text finalCountText;
    public Image cubeScore;
    [Header("Spawn")]
    //Planos de Spawn
    public Vector3 center;
    public Vector3 size;
    public Vector3 center02;
    public Vector3 size02;
    public Vector3 center03;
    public Vector3 size03;
    public Vector3 center04;
    public Vector3 size04;
    public Vector3 center05;
    public Vector3 size05;
    public Vector3 center06;
    public Vector3 size06;
    private Vector3[] spawnPos;
    private int spawnPosition;
    //Objeto Spawn
    public GameObject pickUp;
    public int numPickUp;

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
        numPickUp = 0;

       

    }
	
	// Update is called once per frame
	void Update () {
		if(numPickUp == 1)
        {
            SpawnPickUp();
        }
	}

    void StartGame()
    {
        empezado = true;
        numPickUp = 1;
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

    public void SpawnPickUp()
    {
        //Definimos los valores de los Spawn Points
        spawnPosition = Random.Range(0, 5);
        spawnPos = new Vector3[6];
        spawnPos[0] = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        spawnPos[1] = center02 + new Vector3(Random.Range(-size02.x / 2, size02.x / 2), Random.Range(-size02.y / 2, size02.y / 2), Random.Range(-size02.z / 2, size02.z / 2));
        spawnPos[2] = center03 + new Vector3(Random.Range(-size03.x / 2, size03.x / 2), Random.Range(-size03.y / 2, size03.y / 2), Random.Range(-size03.z / 2, size03.z / 2));
        spawnPos[3] = center04 + new Vector3(Random.Range(-size04.x / 2, size04.x / 2), Random.Range(-size04.y / 2, size04.y / 2), Random.Range(-size04.z / 2, size04.z / 2));
        spawnPos[4] = center05 + new Vector3(Random.Range(-size05.x / 2, size05.x / 2), Random.Range(-size05.y / 2, size05.y / 2), Random.Range(-size05.z / 2, size05.z / 2));
        spawnPos[5] = center06 + new Vector3(Random.Range(-size06.x / 2, size06.x / 2), Random.Range(-size06.y / 2, size06.y / 2), Random.Range(-size06.z / 2, size06.z / 2));

        Instantiate(pickUp,(spawnPos[spawnPosition]), Quaternion.identity);
        numPickUp = numPickUp + 1;
        Debug.Log(numPickUp);
        Debug.Log(spawnPosition);
    }

    private void OnDrawGizmosSelected() //Área en la que pueden spawnear los PickUp
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center,size);
        Gizmos.DrawCube(center02, size02);
        Gizmos.DrawCube(center03, size03);
        Gizmos.DrawCube(center04, size04);
        Gizmos.DrawCube(center05, size05);
        Gizmos.DrawCube(center06, size06);
    }

    
}
