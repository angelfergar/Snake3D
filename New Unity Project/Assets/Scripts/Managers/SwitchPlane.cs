using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlane : MonoBehaviour 
{
	//Instanciamos el objeto player(snake)
	GameObject snake;
	BoxCollider faceCollider;
	public static string exitToEnter = ""; //plano en el que se encuentra
	private string planeToChange="" ;

	void Start () 
	{
		snake = GameObject.FindGameObjectWithTag ("Player");
		faceCollider=this.GetComponent<BoxCollider>();
	}
	
	//cuando el objeto sale del area de influencia, es decir, de esta cara avisa al snake
	void OnTriggerStay(Collider o) {
		if(o.gameObject == snake){
		
		howPlaneChange();
		exitToEnter= CaraController.exitPlane+"To"+planeToChange;

		Debug.Log("Exit To enter: "+exitToEnter);
			
		}
	}

	private void howPlaneChange()
	{
		switch (this.name)
		{
			
			case "Switch_plane":

				planeToChange="Plane_s";
				this.name="Switch_plane-";


			break;
			case "Switch_plane-":

				planeToChange="Plane_main";
				this.name="Switch_plane";


			break;
			case "Switch_plane (1)":

				planeToChange="Plane_w";
				this.name="Switch_plane (1)-";


			break;
			case "Switch_plane (1)-":

				planeToChange="Plane_main";
				this.name="Switch_plane (1)";


			break;
			case "Switch_plane (2)":

				planeToChange="Plane_d";
				this.name="Switch_plane (2)-";


			break;
			case "Switch_plane (2)-":

				planeToChange="Plane_main";
				this.name="Switch_plane (2)";


			break;

			case "Switch_plane (3)":

				planeToChange="Plane_a";
				this.name="Switch_plane (3)-";


			break;
			case "Switch_plane (3)-":

				planeToChange="Plane_main";
				this.name="Switch_plane (3)";


			break;


			
		}
	}

}
