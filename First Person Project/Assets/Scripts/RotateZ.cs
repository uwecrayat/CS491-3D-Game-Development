﻿using UnityEngine;
using System.Collections;

public class RotateZ : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, Mathf.Lerp(0, 360, Time.deltaTime));
	}
}
