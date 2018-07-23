using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaraController : MonoBehaviour 
{
	//Instanciamos el objeto player(snake)
	GameObject snake;
	BoxCollider faceCollider;
	public static string exitPlane = ""; //plano en el que se encuentra

	void Start () 
	{
		snake = GameObject.FindGameObjectWithTag ("Player");
		faceCollider=this.GetComponent<BoxCollider>();
	}
	
		//cuando el objeto sale del area de influencia, es decir, de esta cara avisa al snake
	void OnTriggerExit(Collider o) {

		if(o.gameObject == snake){
			exitPlane= this.name;
		}
		
	}



}
