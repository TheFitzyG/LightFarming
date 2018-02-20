using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class dayNight : MonoBehaviour {

	public float speed = 1f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(transform.right, speed * Time.deltaTime);
		
	}
}
