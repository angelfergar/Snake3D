using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlane : MonoBehaviour 
{
	//Instanciamos el objeto player(snake)
	GameObject snake;
	BoxCollider faceCollider;
	public static string planeToChange="" ;
	private string comePlane="";

	void Start () 
	{
		snake = GameObject.FindGameObjectWithTag ("Player");
		faceCollider=this.GetComponent<BoxCollider>();
	}
	
	//cuando el objeto sale del area de influencia, es decir, de esta cara avisa al snake
	void OnTriggerEnter(Collider o) {
		if(o.gameObject == snake){
		
			howPlaneChange();
			
		}
	}

	private void howPlaneChange()
	{
		comePlane=CaraController.enterPlane;

		switch (this.name)
		{
			
			case "Switch_m<->s":

				if(comePlane.Equals("Plane_main"))
				{
					planeToChange="Plane_s";
				}
				else if(comePlane.Equals("Plane_s"))
				{
					planeToChange="Plane_main";
				}

			break;
			case "Switch_m<->w":

				if(comePlane.Equals("Plane_main"))
				{
					planeToChange="Plane_w";
				}
				else if(comePlane.Equals("Plane_w"))
				{
					planeToChange="Plane_main";
				}

			break;

			case "Switch_m<->d":

				if(comePlane.Equals("Plane_main"))
				{
					planeToChange="Plane_d";
				}
				else if(comePlane.Equals("Plane_d"))
				{
					planeToChange="Plane_main";
				}

			break;
			case "Switch_m<->a":

				if(comePlane.Equals("Plane_main"))
				{
					planeToChange="Plane_a";
				}
				else if(comePlane.Equals("Plane_a"))
				{
					planeToChange="Plane_main";
				}

			break;
			case "Switch_s<->mR":

				if(comePlane.Equals("Plane_s"))
				{
					planeToChange="Plane_mainR";
				}
				else if(comePlane.Equals("Plane_mainR"))
				{
					planeToChange="Plane_s";
				}

			break;
			case "Switch_w<->mR":

				if(comePlane.Equals("Plane_w"))
				{
					planeToChange="Plane_mainR";
				}
				else if(comePlane.Equals("Plane_mainR"))
				{
					planeToChange="Plane_w";
				}

			break;
			case "Switch_d<->mR":

				if(comePlane.Equals("Plane_d"))
				{
					planeToChange="Plane_mainR";
				}
				else if(comePlane.Equals("Plane_mainR"))
				{
					planeToChange="Plane_d";
				}

			break;
			case "Switch_a<->mR":

				if(comePlane.Equals("Plane_a"))
				{
					planeToChange="Plane_mainR";
				}
				else if(comePlane.Equals("Plane_mainR"))
				{
					planeToChange="Plane_a";
				}

			break;
			case "Switch_w<->a":

				if(comePlane.Equals("Plane_w"))
				{
					planeToChange="Plane_a";
				}
				else if(comePlane.Equals("Plane_a"))
				{
					planeToChange="Plane_w";
				}

			break;
			case "Switch_w<->d":

				if(comePlane.Equals("Plane_w"))
				{
					planeToChange="Plane_d";
				}
				else if(comePlane.Equals("Plane_d"))
				{
					planeToChange="Plane_w";
				}

			break;
			case "Switch_a<->s":

				if(comePlane.Equals("Plane_a"))
				{
					planeToChange="Plane_s";
				}
				else if(comePlane.Equals("Plane_s"))
				{
					planeToChange="Plane_a";
				}

			break;
			case "Switch_d<->s":

				if(comePlane.Equals("Plane_d"))
				{
					planeToChange="Plane_s";
				}
				else if(comePlane.Equals("Plane_s"))
				{
					planeToChange="Plane_d";
				}

			break;

		}
	}

}
