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
		Debug.Log("plano actual: "+CaraController.currentPlane);
        if (myGameController.empezado)
        {
            Move(CaraController.currentPlane);

        }
		changePlane(CaraController.currentPlane);

		// if(CaraController.currentPlane.Equals("Plane"))
		// {
		// 	changePlane(CaraController.currentPlane);
		// }

	}

	//Genera el movimiento del personaje con los inputs del teclado...
	void Move(string currentPlane)
	{
		//El objeto siempre va hacia delante
		BodyParts[0].Translate(BodyParts[0].forward*speed*Time.smoothDeltaTime,Space.World);

		//Movimiento evitando diagonales plane 1
		if(Input.GetKey(KeyCode.A))
		{
			switch(currentPlane)
			{
				case "Plane": 
					y=-90;
					break;

				case "Plane_2": 
					x=90;
					break;
			}
       		transform.eulerAngles = new Vector3(x,y,z);
		}
		else if (Input.GetKey(KeyCode.W))
		{
			switch(currentPlane)
			{
				case "Plane": 
					y=0;
					break;

				case "Plane_2": 
					x=0;
					break;
			}
			transform.eulerAngles = new Vector3(x,y,z);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			switch(currentPlane)
			{
				case "Plane": 
					y=90;
					break;

				case "Plane_2": 
					x=-90;
					break;
			}
			transform.eulerAngles = new Vector3(x,y,z);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			switch(currentPlane)
			{
				case "Plane": 
					y=180;
					break;

				case "Plane_2": 
					x=-180;
					break;
			}
			transform.eulerAngles = new Vector3(x,y,z);
		}

	}
	
	//añadimos partes a la cola del snake
	public void AddBodyPart()
	{
		Transform newPart=(Instantiate(colaPrefab,BodyParts[BodyParts.Count-1].position, BodyParts[BodyParts.Count-1].rotation) as GameObject).transform;
		newPart.SetParent(transform);
		BodyParts.Add(newPart);
	}

	private void changePlane(string plane)
	{
		switch(plane)
		{
			case "Plane": 
				x=0;
				transform.eulerAngles = new Vector3(x,y,z);
				break;

			case "Plane_2": 
				x=90;
				transform.eulerAngles = new Vector3(x,y,z);
				break;

			default: 
				x=0;
				break;

		}
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
    }

}
