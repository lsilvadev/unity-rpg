using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportBehaviour : MonoBehaviour {

    private Camera _camera;
    public Transform point;

	void Start () 
    {
        _camera = Camera.main;
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (point==null)
        {
            Debug.Log("TransportBehaviour - Point Error");
        }
        else
        {
            col.transform.position = point.transform.position;
            _camera.gameObject.transform.position = point.transform.position + new Vector3(0, 0, -10);
        }


    }
	
}
