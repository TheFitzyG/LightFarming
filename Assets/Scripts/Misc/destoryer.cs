using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryer : MonoBehaviour {


	public string item;
	public string tool;
	
	public void destroy() {
		
		if (playerInventory.selectedItem == (hotbar)System.Enum.Parse(typeof(hotbar), tool)){

			playerInventory.inventory[item]++;


			Destroy(gameObject);

		}


	}
}
