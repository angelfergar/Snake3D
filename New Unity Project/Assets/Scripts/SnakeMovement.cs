using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

   //velocidad de movimiento del snake
    public float speed =1f;
	
    //Define el movimiento del player en base a las teclas que se pulsen
    Vector3 movement; 
	Rigidbody snakeRigibody;

	void Start () 
	{
		snakeRigibody= GetComponent<Rigidbody>();

	}
	
	void FixedUpdate()
	{
		//Inicializamos variables 
		float moveHorizontal= Input.GetAxis("Horizontal");
		float moveVertical= Input.GetAxis("Vertical");

		//Llamamos a la función Move 
		Move(moveHorizontal,moveVertical);
	}

	//Genera el movimiento del personaje con los inputs del teclado...
	void Move(float h, float v)
	{
		movement.Set(h,0f,v);
		movement= movement.normalized * speed * Time.deltaTime;
		snakeRigibody.MovePosition(transform.position+movement);//colisión con objetos de la escena

	}

}
