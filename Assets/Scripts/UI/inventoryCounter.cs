using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inventoryCounter : MonoBehaviour {
    public string item;

    public GameObject selector;
    
    void Start() {

        selector = transform.Find("Selected").gameObject;


    }


    // Update is called once per frame
    void FixedUpdate() {
        
        GetComponentInChildren<Text>().text = playerInventory.inventory[item].ToString();

        if (playerInventory.selectedItem.ToString() == item) { 
        
        selector.SetActive(true);
            
        }
        else { 
        
        selector.SetActive(false);
            
        }


    }
}