using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour {

	public UnityEvent interacted;
	
	public void interact() {
		
		Debug.Log("Interacted with: "+ gameObject.ToString());

		interacted.Invoke();

	}
}
