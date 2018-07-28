using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject reference;
    private Vector3 offset;
    public Vector3 rotation;
    

	// Update is called once per frame
	void Start () {

        offset = transform.position - reference.transform.position;
        rotation = transform.rotation.eulerAngles;
	}

    private void LateUpdate() //Se ejecuta cada frame, pero una vez se han terminado todas las acciones de los Update
    {
        transform.position = reference.transform.position + offset;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
