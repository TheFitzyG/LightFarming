using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public GameObject toSpawn;

	public string itemCost;
	//public string item;
	
	public void spawn() {


		if (playerInventory.selectedItem == (hotbar)System.Enum.Parse(typeof(hotbar), itemCost)  && playerInventory.inventory[itemCost] > 0) {

			GameObject spawned = Instantiate(toSpawn, transform.position, transform.rotation);
			spawned.transform.parent = transform;
			playerInventory.inventory[itemCost]--;


		}


	}
}
