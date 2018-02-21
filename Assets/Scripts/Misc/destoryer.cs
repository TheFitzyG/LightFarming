using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryer : MonoBehaviour {


	public string item;
	//ublic string tool;

	public hotbar tool;
	
	public void destroy() {
		
		if (playerInventory.selectedItem == tool){//playerInventory.selectedItem == (hotbar)System.Enum.Parse(typeof(hotbar), tool)){

			playerInventory.inventory[item]++;


			Destroy(gameObject);

		}
		else { 
		
		Debug.Log("NOPE");
		
		}


	}
}
