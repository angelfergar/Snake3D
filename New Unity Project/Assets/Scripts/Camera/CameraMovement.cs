using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject reference;
    private Vector3 offset;
    

	// Update is called once per frame
	void Start () {

        offset = transform.position - reference.transform.position;
	}

    private void LateUpdate() //Se ejecuta cada frame, pero una vez se han terminado todas las acciones de los Update
    {
        transform.position = reference.transform.position + offset; 
    }
}
