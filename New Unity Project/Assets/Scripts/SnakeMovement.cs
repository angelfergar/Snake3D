using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

   //velocidad de movimiento del snake
    public float speed;
	public float rotationSpeed;
	public float minDistance;
	public List<Transform> BodyParts = new List<Transform>();
	public GameObject colaPrefab;
	public int beginSize;
	
    //Define el movimiento del player en base a las teclas que se pulsen
    private Vector3 movement; 
	private float distance;
	private Transform currentBodyPart;
	private Transform prevBodyPart;

	void Start () 
	{
		for (int i = 0; i < beginSize - 1 ; i++)
		{
			AddBodyPart();
		}
	}

	void Update()
	{
		Move();

		if(Input.GetKey(KeyCode.Q))
		{
			AddBodyPart();
		}
	}

	//Genera el movimiento del personaje con los inputs del teclado...
	void Move()
	{
		//Velocidad actual del snake	
		float currentSpeed= speed;

		//esperando una translación o rotación del snake.
		if(Input.GetKey(KeyCode.W))
		
			currentSpeed*=2;

		BodyParts[0].Translate(BodyParts[0].forward*currentSpeed*Time.smoothDeltaTime,Space.World);
		
		if(Input.GetAxis("Horizontal")!=0)
		
		BodyParts[0].Rotate(Vector3.up * rotationSpeed *Time.deltaTime*Input.GetAxis("Horizontal"));


		//empezamos a contar los objetos que siguen a la cabeza
		for (int i = 1; i < BodyParts.Count; i++)
		{
			currentBodyPart=BodyParts[i];
			prevBodyPart= BodyParts[i-1];

			//distancia entre las dos partes del cuerpo
			distance= Vector3.Distance(prevBodyPart.position, currentBodyPart.position);

			Vector3 newPos= prevBodyPart.position;

			newPos.y= BodyParts[0].position.y;

			float T= Time.deltaTime * distance/minDistance*currentSpeed;
			//evitar el colapso de objetos
			if(T>0.5f)
			{
				T=0.5f;
				currentBodyPart.position = Vector3.Slerp(currentBodyPart.position,newPos,T);
				currentBodyPart.rotation = Quaternion.Slerp(currentBodyPart.rotation , prevBodyPart.rotation , T);
			}

		}

	}
	
	//añadimos partes a la cola del snake
	public void AddBodyPart()
	{
		Transform newPart=(Instantiate(colaPrefab,BodyParts[BodyParts.Count-1].position, BodyParts[BodyParts.Count-1].rotation) as GameObject).transform;
		newPart.SetParent(transform);
		BodyParts.Add(newPart);
	}


}
