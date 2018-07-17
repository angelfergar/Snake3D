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
	public float minDistance;
	public List<Transform> BodyParts = new List<Transform>();
	public GameObject colaPrefab;
	public int beginSize;
	
	//Variables privadas
    //Define el movimiento del player en base a las teclas que se pulsen
    private Vector3 movement; 
	private float distance;
	private Transform currentBodyPart;
	private Transform prevBodyPart;


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

            if (Input.GetKey(KeyCode.Q))
            {
                AddBodyPart();
            }

        }
	}

	//Genera el movimiento del personaje con los inputs del teclado...
	void Move()
	{

		//El objeto siempre va hacia delante
		BodyParts[0].Translate(BodyParts[0].forward*speed*Time.smoothDeltaTime,Space.World);


		//Movimiento evitando diagonales
		if(Input.GetKey(KeyCode.A))
		{
       		 transform.eulerAngles = new Vector3(0,-90,0);
		}
		else if (Input.GetKey(KeyCode.W))
		{
			transform.eulerAngles = new Vector3(0,0,0);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			transform.eulerAngles = new Vector3(0,90,0);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			transform.eulerAngles = new Vector3(0,180,0);
		}
		
		//Empezamos a contar los objetos que siguen a la cabeza
		// for (int i = 1; i < BodyParts.Count; i++)
		// {
		// 	currentBodyPart=BodyParts[i];
		// 	prevBodyPart= BodyParts[i-1];

		// 	//distancia entre las dos partes del cuerpo
		// 	distance= Vector3.Distance(prevBodyPart.position, currentBodyPart.position);

		// 	Vector3 newPos= prevBodyPart.position;

		// 	newPos.y= BodyParts[0].position.y;

		// 	float T= Time.deltaTime * distance/minDistance*currentSpeed;
		// 	//evitar el colapso de objetos
		// 	if(T>0.5f)
		// 	{
		// 		T=0.5f;
		// 		currentBodyPart.position = Vector3.Slerp(currentBodyPart.position,newPos,T);
		// 		currentBodyPart.rotation = Quaternion.Slerp(currentBodyPart.rotation , prevBodyPart.rotation , T);
		// 	}

		// }

	}
	
	//añadimos partes a la cola del snake
	public void AddBodyPart()
	{
		Transform newPart=(Instantiate(colaPrefab,BodyParts[BodyParts.Count-1].position, BodyParts[BodyParts.Count-1].rotation) as GameObject).transform;
		newPart.SetParent(transform);
		BodyParts.Add(newPart);
	}


}
