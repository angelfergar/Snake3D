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

	[Header("bodyParts")]
	public List<GameObject> bodyParts = new List<GameObject>();
	public GameObject bodyPartsPrefab;
	public int beginSize;
	public float disEntrabodyParts;
	
	//Variables privadas
    //Define el movimiento del player en base a las teclas que se pulsen
	private string dir="";
	private string orientation="main";
	//comprobar si la posición del objeto 
	private float x,y,z;
	
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
		//Movimiento evitando diagonales plane Horizontal
		switch(orientation)
		{
			case "w":

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
					dir="down";
				}
				else if (Input.GetKey(KeyCode.S))
				{
					dir="up";
				}
			break;
			case "s":

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
					dir="up";
				}
				else if (Input.GetKey(KeyCode.S))
				{
					dir="down";
				}
			break;
			case "a":

				if(Input.GetKey(KeyCode.A))
				{
					dir="down";
				}
				else if (Input.GetKey(KeyCode.D))
				{
					dir="up";
				}
				else if (Input.GetKey(KeyCode.W))
				{
					dir="forward";
				}
				else if (Input.GetKey(KeyCode.S))
				{
					dir="behind";
				}
			break;
			case "d":

				if(Input.GetKey(KeyCode.A))
				{
					dir="up";
				}
				else if (Input.GetKey(KeyCode.D))
				{
					dir="down";
				}
				else if (Input.GetKey(KeyCode.W))
				{
					dir="forward";
				}
				else if (Input.GetKey(KeyCode.S))
				{
					dir="behind";
				}
			break;
			case "main":

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
			break;

			default:
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
			break;

		}

		switch(dir)
		{
			case "forward":
				transform.Translate( bodyParts[0].transform.forward*speed*Time.smoothDeltaTime,Space.World);
			break;
			case "behind":
				transform.Translate(-bodyParts[0].transform.forward*speed*Time.smoothDeltaTime,Space.World);
			break;
			case "left":
				transform.Translate(-bodyParts[0].transform.right*speed*Time.smoothDeltaTime,Space.World);
			break;
			case "right":
				transform.Translate( bodyParts[0].transform.right*speed*Time.smoothDeltaTime,Space.World);
			break;
			case "up":
				transform.Translate( bodyParts[0].transform.up*speed*Time.smoothDeltaTime,Space.World);
			break;
			case "down":
				transform.Translate(-bodyParts[0].transform.up*speed*Time.smoothDeltaTime,Space.World);
			break;
			default:
				transform.Translate( bodyParts[0].transform.forward*speed*Time.smoothDeltaTime,Space.World);
			break;
		}	

		//Movimiento de el body del snake 
		for (int i = 1; i < bodyParts.Count; i++)
		{
			Vector3 prevPos= bodyParts[i-1].transform.position;
			Vector3 currPos= bodyParts[i].transform.position;

			float distancia= Vector3.Distance(prevPos,currPos);
			//Si la distancia es mayor a la min distancia entre ambos objetos, movemos el objeto.
			if(distancia>=disEntrabodyParts) 
			bodyParts[i].transform.position= Vector3.MoveTowards(currPos,prevPos,speed*Time.smoothDeltaTime);
		}
	}
	
	//añadimos partes a la cola del snake
	public void AddBodyPart()
	{
		Vector3 posCurr= bodyParts[bodyParts.Count-1].transform.position;
		// newPart=(Instantiate(bodyPartsPrefab,posCurr,bodyParts[bodyParts.Count-1].rotation) as GameObject).transform;
		GameObject newPart=Instantiate(bodyPartsPrefab,posCurr,bodyParts[bodyParts.Count-1].transform.rotation);
		// newPart.SetParent(transform);
		bodyParts.Add(newPart);
	}

	private void changePlane()
	{
		switch(CaraController.exitToEnter)
		{
			//PLANO MAIN
			case "Plane_mainToPlane_s":orientation="s";dir="down";break;case "Plane_mainToPlane_w":orientation="w";dir="down";break;
			case "Plane_mainToPlane_a":orientation="a";dir="down";break;case "Plane_mainToPlane_d":orientation="d";dir="down";break;

			//PLANO W
			case "Plane_wToPlane_main":orientation="main";dir="behind";break;case "Plane_wToPlane_mainR":orientation="main";dir="behind";break;
			case "Plane_wToPlane_a":orientation="a";dir="behind";break;case "Plane_wToPlane_d":orientation="d";dir="behind";break;
			//PLANO A
			case "Plane_aToPlane_main":orientation="main";dir="right";break;case "Plane_aToPlane_mainR":orientation="main";dir="right";break;
			case "Plane_aToPlane_w":orientation="w";dir="right";break;case "Plane_aToPlane_s":orientation="s";dir="right";break;
			//PLANO S
			case "Plane_sToPlane_main":orientation="main";dir="forward";break;case "Plane_sToPlane_mainR":orientation="main";dir="forward";break;
			case "Plane_sToPlane_a":orientation="a";dir="forward";break;case "Plane_sToPlane_d":orientation="d";dir="forward";break;
			//PLANO D
			case "Plane_dToPlane_main":orientation="main";dir="left";break;case "Plane_dToPlane_mainR":orientation="main";dir="left";break;
			case "Plane_dToPlane_w":orientation="w";dir="left";break;case "Plane_dToPlane_s":orientation="s";dir="left";;break;

			//PLANO REVERSE
			case "Plane_mainRToPlane_s":orientation="s";dir="up";break;case "Plane_mainRToPlane_w":orientation="w";dir="up";break;
			case "Plane_mainRToPlane_a":orientation="a";dir="up";break;case "Plane_mainRToPlane_d":orientation="d";dir="up";break;
		}
		CaraController.exitToEnter="";
		
	}

    //Detectar colisión con el pickup y que este se desactive y sume uno al conteo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            myGameController.count++;
            myGameController.SetCountText();
            myGameController.numPickUp--;

			//añadimos una parte al body del snake
			AddBodyPart();
            
        }
        if (other.gameObject.CompareTag("Muerte"))
        {
            myGameController.Dead();
        }
    }

}
