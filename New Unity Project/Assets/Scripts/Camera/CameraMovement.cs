using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {


    public GameObject referenceUp;
    public Vector3 rotationUp;
    public GameObject referenceRight;
    public Vector3 rotationRight;


    // Update is called once per frame
    void Start()
    {

        rotationUp = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(rotationUp);
        transform.position = referenceUp.transform.position; 

    }


    public void CameraUpToRight()
    {
        transform.position = referenceRight.transform.position;
        transform.rotation = Quaternion.Euler(rotationRight);
    }

}
