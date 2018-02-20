using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightAdjust : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {

		GetComponent<CircleCollider2D>().radius = GetComponent<Light>().range * (4f/5f);

	}
}
