﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerController player;
    private new CameraController camera;
    public Vector2 startDirection;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        player.transform.position = transform.position;
        player.lastMove = startDirection;

        camera = FindObjectOfType<CameraController>();
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
