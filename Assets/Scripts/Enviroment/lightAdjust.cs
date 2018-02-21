using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightAdjust : MonoBehaviour {
	private Light light;
	private float minTencity;
	private float maxTencity;

	private float randy;

	[Range(0,1)]
	public float percFlick = 0.1f;

	void Start() {

		light = GetComponent<Light>();

		minTencity = light.intensity * (1 - percFlick);
		maxTencity = light.intensity;

		
randy = rand();


	}


	float rand() {

		float random = Random.Range(0f, 10f);
		return random;

	}


	// Update is called once per frame
	void Update () {

		float noise = Mathf.PerlinNoise(randy, Time.time);
		//light.intensity = Mathf.Lerp(minTencity, maxTencity, noise);

		GetComponent<CircleCollider2D>().radius = GetComponent<Light>().range * (4f/5f);

	}
}
