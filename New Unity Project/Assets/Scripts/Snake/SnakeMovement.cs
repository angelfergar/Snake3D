using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    [Header("Game Controller")]

    public GameObject gameControllerObject; //Variable para llamar al GameController
    private GameController myGameController; //Con esto sacaremos los componentes del GameController

    [Header("Movement")]

    //Variables públicas
    public float speed;//velocidad del snake

	[Header("Body")]
	public float minDistance;
	public List<Transform> BodyParts = new List<Transform>();
	public GameObject colaPrefab;
	public int beginSize;
	
	//Variables privadas
    //Define el movimiento del player en base a las teclas que se pulsen
	private Transform currentBodyPart;
	private Transform prevBodyPart;
	private string dir="";


	// grados del objeto
	private int x=0,y=0,z=0;

	void Start () 
	{
        myGameController = gameControllerObject.GetComponent<GameController>();

		for (int i = 0; i < beginSize - 1 ; i++)
		{
			AddBodyPart();
		}
	}

	void Update()
	{
		
        if (myGameController.empezado)
        {
            Move();
        }

		//Se tiene que ejecutar una vez en el cambio de plano por lo tanto ponemos el currentPlane a ""
		changePlane();

	}

	//Genera el movimiento del personaje con los inputs del teclado...
	void Move()
	{
		
		//Movimiento evitando diagonales plane 1
		if(Input.GetKey(KeyCode.A))
		{
			dir="left";
		}
		else if (Input.GetKey(KeyCode.D))
		{
			dir="right";
		}
		else if (Input.GetKey(KeyCode.W))
		{
			dir="forward";
		}
		else if (Input.GetKey(KeyCode.S))
		{
			dir="behind";
		}
		switch(dir)
		{
			case "forward":
				transform.Translate( BodyParts[0].forward*speed*Time.smoothDeltaTime,Space.World);
			break;
			case "behind":
				transform.Translate(-BodyParts[0].forward*speed*Time.smoothDeltaTime,Space.World);
			break;
			case "left":
				transform.Translate(-BodyParts[0].right*speed*Time.smoothDeltaTime,Space.World);
			break;
			case "right":
				transform.Translate( BodyParts[0].right*speed*Time.smoothDeltaTime,Space.World);
			break;
			default:
				transform.Translate( BodyParts[0].forward*speed*Time.smoothDeltaTime,Space.World);
			break;
		}

	}
	
	//añadimos partes a la cola del snake
	public void AddBodyPart()
	{
		Transform newPart=(Instantiate(colaPrefab,BodyParts[BodyParts.Count-1].position, BodyParts[BodyParts.Count-1].rotation) as GameObject).transform;
		newPart.SetParent(transform);
		BodyParts.Add(newPart);
	}

	private void changePlane()
	{
		
		switch(SwitchPlane.exitToEnter)
		{
			//PLANO MAIN
			case "Plane_mainToPlane_s":x=-90;break;case "Plane_mainToPlane_w":x=90;break;
			case "Plane_mainToPlane_a":z=90;break;case "Plane_mainToPlane_d":z=-90;break;

			//PLANO W
			case "Plane_wToPlane_main":x=0;break;
			//PLANO A
			case "Plane_aToPlane_main":z=0;break;
			//PLANO S
			case "Plane_sToPlane_main":x=0;break;
			//PLANO D
			case "Plane_dToPlane_main":z=0;break;
		}
		transform.eulerAngles = new Vector3(x,y,z);
		
	}

    //Detectar colisión con el pickup y que este se desactive y sume uno al conteo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            myGameController.count = myGameController.count + 1;
            myGameController.SetCountText();
            
        }
        if (other.gameObject.CompareTag("Muerte"))
        {
            myGameController.Dead();
        }
    }

}
