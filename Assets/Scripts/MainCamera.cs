using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    
    //[SerializeField] Transform faceCam;
    //[SerializeField] Transform lookAt;
    private float _speedCam = 1.5f;
    void Update()
    {
        //transform.position = faceCam.position;
        
        //Ray _cam = Camera.main.ScreenPointToRay(Input.mousePosition);
        //transform.LookAt(_cam.direction);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * Time.deltaTime * _speedCam);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * Time.deltaTime * _speedCam);
        }

        //Vector3 lerp = Vector3.Lerp(transform.position, faceCam.position, Time.deltaTime * _speedCam);
        //transform.position = faceCam.position;
        //transform.LookAt(lookAt.position);
    }
}
